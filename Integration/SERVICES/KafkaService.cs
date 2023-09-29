using Microsoft.Extensions.Logging;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Web;
using $ext_safeprojectname$.Common.Configurations;
using $ext_safeprojectname$.Integration.Interfaces;

namespace $ext_safeprojectname$.Integration.Services
{
    internal class KafkaService : ServiceBase<IKafkaService>, IKafkaService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public KafkaService(AppSettings appSettings, 
            ILogger<IKafkaService> logger, 
            IHttpClientFactory httpClientFactory) : base(appSettings, logger)
        {
            _httpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// Used for sending payloads that are in memory 
        /// </summary>
        /// <typeparam name="T">Data Type</typeparam>
        /// <param name="client">kafka url - will create client based off configuration if null</param>
        /// <param name="kafkaTopic">entity name/ kafka topic to post to - will take from config if null or empty</param>
        /// <param name="payload">Data to send to kafka endpoint</param>
        public void MakeApiCall<T>(HttpClient client, string kafkaTopic, IEnumerable<T> payload)
        {
            MakeApiCall(client, kafkaTopic, payload.Count(), (skip, take) => payload.Skip(skip).Take(take));
        }

        /// <summary>
        /// Use for sending larger payloads where you don't want to load all data into memory, it will chunk the data and send it in batches
        /// </summary>
        /// <typeparam name="T">Data Type </typeparam>
        /// <param name="client">kafka url - will create client based off configuration if null</param>
        /// <param name="kafkaTopic">entity name/ kafka topic to post to - will take from config if null or empty</param>
        /// <param name="payloadCount">rough count of payload, this will feed into the chunking process</param>
        /// <param name="payloadMethod">method that will be invoked to pull more data  method(int skip, int take) returns payload</param>
        public void MakeApiCall<T>(HttpClient client, string kafkaTopic, int payloadCount , Func<int,int,IEnumerable<T>> payloadMethod)
        {
            _logger.LogInformation($"Kafka API Call {DateTime.Now}");
            var chunkCount = 0;

            if (payloadCount > 0)
            { 
                _logger.LogInformation($"Payload size {payloadCount:N2}");

                int takeCount = _appSettings.KafkaApi.Batchsize;
                _logger.LogInformation($"Batch size {takeCount}");

                var dict = new Dictionary<int, int>();

                _logger.LogInformation("Creating Chunks");

                while ((chunkCount + takeCount) < payloadCount)
                {
                    dict.TryAdd(chunkCount, takeCount);
                    chunkCount += takeCount;
                }
                dict.TryAdd(chunkCount, takeCount);
                foreach (var item in dict)
                {
                    _logger.LogInformation($"Skip: {item.Key} Take {item.Value}");
                }

                if(client == null)
                {
                    _logger.LogInformation("HttpClient Null");
                    _logger.LogInformation("Creating HttpClient");
                    client = _httpClientFactory.CreateClient((nameof(_appSettings.KafkaApi)));
                }

                var query = HttpUtility.ParseQueryString(string.Empty);

                if (string.IsNullOrEmpty(kafkaTopic))
                {
                    _logger.LogInformation("kafkaTopic Null");
                    _logger.LogInformation($"using appsettings : {_appSettings.KafkaApi.EntityName}");
                    query["entityName"] = _appSettings.KafkaApi.EntityName;
                }
                else
                {
                    _logger.LogInformation($"kafkaTopic {kafkaTopic}");
                    query["entityName"] = kafkaTopic;

                }
                var queryString = query.ToString();

                var queryBuilder = new UriBuilder(client.BaseAddress)
                {
                    Path = "api/data",
                    Query = queryString
                };

                _logger.LogInformation($"HttpClient: {nameof(client.BaseAddress)} : {client.BaseAddress}");

                Parallel.ForEach(dict, (item) =>
                {
                    var chunkName = $"{item.Key}-{(item.Key + item.Value)}";
                    _logger.LogInformation($"Getting Chunk: {chunkName}: {DateTime.Now}");

                    var chunk = payloadMethod.Invoke(item.Key, item.Value);
                    try
                    {

                        //var jsonOptions = new JsonSerializerOptions();
                        //jsonOptions.Converters.Add(new CustomDateTimeConverter("yyyy-MM-dd HH:mm:ss"));

                        _logger.LogInformation($"Processing and Sending Chunk: {chunkName}: {DateTime.Now}");

                        //var content = new StringContent(JsonSerializer.Serialize(chunk, jsonOptions), Encoding.UTF8,
                        var content = new StringContent(JsonSerializer.Serialize(chunk), Encoding.UTF8,
                        MediaTypeNames.Application.Json);

                        // True Async will cause some calls to fail
                        var resp = client.PostAsync(queryBuilder.ToString(), content).GetAwaiter().GetResult();

                        if (resp.IsSuccessStatusCode)
                        {
                            _logger.LogInformation($"Response From Processing and Sending Chunk {chunkName}: Status Code:{resp.StatusCode}");
                        }
                        else
                        {
                            _logger.LogError($"Response From Processing and Sending Chunk {chunkName}: Status Code:{resp.StatusCode} : {resp.ReasonPhrase}");
                        }

                    }
                    catch (AggregateException ex)
                    {
                        _logger.LogError($"Error in processing and Sending Chunk: {chunkName} : {DateTime.Now}");
                        _logger.LogError(ex.Message);
                        _logger.LogError(ex.StackTrace);
                        _logger.LogError(ex.InnerException?.Message);
                    }

                });

                _logger.LogInformation($"Finished MakeApiCall");


            }
            else
            {
                _logger.LogInformation($"Empty Payload");
            }
        }

    }
}
