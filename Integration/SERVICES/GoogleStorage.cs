using CsvHelper;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using Microsoft.Extensions.Logging;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using $ext_safeprojectname$.Common.Configurations;
using $ext_safeprojectname$.Integration.Interfaces;

namespace $ext_safeprojectname$.Integration.Services
{
    internal class GoogleStorage : ServiceBase<IGoogleStorage>, IGoogleStorage
    {
        private readonly GoogleJsonKey _googleJsonKey;
        public GoogleStorage(AppSettings appSettings, ILogger<IGoogleStorage> logger, GoogleJsonKey googleJsonKey) 
            : base(appSettings, logger)
        {
            this._googleJsonKey = googleJsonKey;
        }

        public MemoryStream ConvertObjectToCsvStream<T>(IEnumerable<T> lst)
        {
            var memoryStream = new MemoryStream();
            var streamWriter = new StreamWriter(memoryStream, Encoding.UTF8);
            var csvWriter = new CsvWriter(streamWriter, System.Globalization.CultureInfo.InvariantCulture);

            csvWriter.WriteRecords(lst);
            streamWriter.Flush(); // Important to make sure all data is written to the MemoryStream
            memoryStream.Position = 0; // Reset the MemoryStream position for reading

            return memoryStream;
        }

        public void TestUpload(string bucket,
            string fileName,
            string contentType,
            Stream source)
        {
            var creds = GoogleCredential.FromJson(JsonSerializer.Serialize(_googleJsonKey));
            var client = StorageClient.Create(creds);

            // Upload some files
            _ = client.UploadObject(bucket, fileName, contentType, source);
            // var obj2 = client.UploadObject(bucketName, "folder1/file2.txt", "text/plain", new MemoryStream(content));

            // List objects
            //foreach (var obj in client.ListObjects(bucketName, ""))
            //{
            //    Console.WriteLine(obj.Name);
            //}

            //// Download file
            //using (var stream = File.OpenWrite("file1.txt"))
            //{
            //    client.DownloadObject(bucketName, "file1.txt", stream);
            //}
        }

        public void BulkStorageUpload<T>(string bucket, string fileName, string contentType, int payloadCount, Func<int, int, IEnumerable<T>> payloadMethod)
        {
            _logger.LogInformation($"Google Storage API Call {DateTime.Now}");
            var chunkCount = 0;

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
            var creds = GoogleCredential.FromJson(JsonSerializer.Serialize(_googleJsonKey));
            var client = StorageClient.Create(creds);

            Parallel.ForEach(dict, (item) =>
            {
                var chunkName = $"{item.Key}-{(item.Key + item.Value)}";
                _logger.LogInformation($"Getting Chunk: {chunkName}: {DateTime.Now}");

                var chunk = payloadMethod.Invoke(item.Key, item.Value);
                try
                {
                    _logger.LogInformation($"Processing and Sending Chunk: {chunkName}: {DateTime.Now}");
                    if((chunk?.Count() ?? 0) > 0)
                    {
                        _ = client.UploadObject(bucket, $"{fileName}_{item.Key}", contentType, ConvertObjectToCsvStream(chunk));
                    }
                    else
                    {
                        _logger.LogInformation($"Chunk Was Null/Empty: {chunkName}: {DateTime.Now}");
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

            _logger.LogInformation($"Finished BulkStorageUpload");
        }
    }
}
