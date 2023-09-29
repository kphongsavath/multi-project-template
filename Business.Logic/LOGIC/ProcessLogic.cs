using AutoMapper;
using Microsoft.Extensions.Logging;
using $ext_safeprojectname$.Business.Common.Model;
using $ext_safeprojectname$.Business.Logic.Interfaces;
using $ext_safeprojectname$.Common.Configurations;
using $ext_safeprojectname$.DataAccess.Interfaces;
using $ext_safeprojectname$.Integration.Interfaces;

namespace $ext_safeprojectname$.Business.Logic.Logic
{
    /*
        Remove unused references/parameters/properties as needed
    */
    internal class ProcessLogic : LogicBase<IProcessLogic>, IProcessLogic
    {
        private readonly IProcessRepository _processRepository;
        private readonly IEmailService _emailService;
        private readonly IKafkaService _kafkaService;
        private readonly IExcelFileService _excelFileService;
        private readonly IGoogleStorage _storage;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMapper _mapper;


        public ProcessLogic(AppSettings appSettings, ILogger<IProcessLogic> logger,
            IEmailService emailService,
            IProcessRepository processRepository,
            IKafkaService kafkaService,
            IExcelFileService excelFileService,
            IHttpClientFactory httpClientFactory, 
            IGoogleStorage storage,
            IMapper mapper) : base(appSettings, logger)
        {
            _emailService = emailService;
            _processRepository = processRepository;
            _kafkaService = kafkaService;
            _excelFileService = excelFileService;
            _httpClientFactory = httpClientFactory;
            _storage = storage;
            _mapper = mapper;
        }

        protected override void Process()
        {

            // Insert Logic Here




            /***  Examples   ***/
            // BulkInsertExample();
            //KafkaWithChunkExample();
            //ExcelFileCreationExample();


            //SendEmailExamples();
            
            //var results = _processRepository.Articles("sefesfeffessf");
            
            
            //StorageExampleWithLargeDataSet();

            //_logger.LogInformation($"Total Record Count: {results.Count()}");

        }


        /// <summary>
        /// Bulk Insert Example
        /// </summary>
        public void BulkInsertExample()
        {
            //EF Core With Count, Skip and Take
            var records = _processRepository.Articles("112233");
            var recordCount = (records?.Count() ?? 0);
            _logger.LogInformation($"Total Record Count: {recordCount:N0}");

            if (recordCount > 0)
            {
                _processRepository.SqlBulkCopyWithCollection(records.ToArray());
            }
        }

        /// <summary>
        /// Example of sending Kafka with Chunking and without Chunking
        /// </summary>
        public void KafkaWithChunkExample()
        {
            //EF Core With Count, Skip and Take
            var recordCount = _processRepository.VsEpConfigurationsCount();
            _logger.LogInformation($"Total Record Count: {recordCount:N0}");
            if (recordCount > 0)
            {
                var client = _httpClientFactory.CreateClient((nameof(_appSettings.KafkaApi)));
                // Processing Chunks with Count, Skip and Take
                _kafkaService.MakeApiCall(client, _appSettings.KafkaApi.EntityName, recordCount, (skip, take) => {
                    return _processRepository.VsEpConfigurationsBatch(skip, take);
                });


                // Process data with complete records
                var completeData = _processRepository.VsEpConfigurations();
                _kafkaService.MakeApiCall(client, _appSettings.KafkaApi.EntityName, completeData);
            }
        }

        /// <summary>
        /// Export to Excel File Example with and without file location and file name
        /// </summary>
        public void ExcelFileCreationExample()
        {
            //Get data from database for Excel
            var data = _processRepository.VsEpConfigurations();

            //Create file Path for Excel File
            var fullFilePath = Path.Combine(_appSettings.FileArguments.ExportFileLocation, _appSettings.FileArguments.ExportFile);
            // If you want to build your own file location and file name
            _excelFileService.ExportToExcelFile(data, _appSettings.FileArguments.ExportFileLocation, _appSettings.FileArguments.ExportFile);



            //If you want to use the default file location and file name
            _excelFileService.ExportToExcelFile<object>(data);

        }

        /// <summary>
        /// Sending Email With and Without Attachment
        /// </summary>
        public void SendEmailExamples()
        {
            //Basic Email
            _emailService.SendAsync("from", "to", "subject", "body");

            //Email with attachment
            _emailService.SendAsync((msg) =>
            {
                //Get data from database
                var data = _processRepository.VsEpConfigurations();

                //Create file Path
                var fullFilePath = Path.Combine(_appSettings.FileArguments.ExportFileLocation, _appSettings.SmtpSettings.AttachmentName);

                //Export to Excel File Location
                _excelFileService.ExportToExcelFile<object>(data, fullFilePath);

                _logger.LogInformation($"Sending Email Notification");

                // Set other values if needed
                msg.Body = "Email Example that has Attachment";

                //Attach file from file location
                msg.Attachments.Add(new System.Net.Mail.Attachment(File.OpenRead(fullFilePath), _appSettings.SmtpSettings.AttachmentName));
            });


            //Email without attachment
            _emailService.SendAsync((msg) =>
            {
                _logger.LogInformation($"Sending Email Notification");
                msg.Body = "Email Example that has Attachment";
                //Set other values if needed
            });

        }

        /// <summary>
        /// Google Storage Example
        /// </summary>
        public void StorageExample()
        {
            var data = _processRepository.VsEpConfigurations();
            _storage.TestUpload(_appSettings.GoogleApi.StorageApi.BucketName, "test.txt", "text/plain", _storage.ConvertObjectToCsvStream(data));
        }

        public void StorageExampleWithLargeDataSet()
        {
            var records = _processRepository.Articles("112233");
            var recordCount = (records?.Count() ?? 0);
            _logger.LogInformation($"Total Record Count: {recordCount:N0}");
            _storage.BulkStorageUpload(_appSettings.GoogleApi.StorageApi.BucketName,_appSettings.GoogleApi.StorageApi.FileName, "text/plain", 100000, (skip, take) => {
                var result = _processRepository.ArticleDataBatch(skip, take);
                if(result?.Count() > 0)
                {
                    return _mapper.Map<IEnumerable<Articles>>(result);
                }
                return default;
            });
        }
    }
}
