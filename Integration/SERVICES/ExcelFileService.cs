using Microsoft.Extensions.Logging;
using System.Data;
using $ext_safeprojectname$.Common.Configurations;
using $ext_safeprojectname$.Integration.Excel;
using $ext_safeprojectname$.Integration.Interfaces;

namespace $ext_safeprojectname$.Integration.Services
{
    internal class ExcelFileService : BaseReader<IExcelFileService>, IExcelFileService
    {
        public ExcelFileService(AppSettings appSettings, ILogger<IExcelFileService> logger) : base(appSettings, logger)
        {


        }

        public void ExportToExcelFile<T>(IEnumerable<T> dataToExport, string exportFileLocation = null, string exportFileName = null)
        {
            _logger.LogInformation("ExportToExcelFile Start");

            if (dataToExport == null)
            {
                _logger.LogWarning("ExportToExcelFile dataToExport is null");
                return;
            }
            var FullFilePath = Path.Combine(exportFileLocation ?? _appSettings.FileArguments.ExportFileLocation, exportFileName ?? _appSettings.FileArguments.ExportFile);

            ExportFileContent(dataToExport, FullFilePath);
        }




        public void LoadFileForProcessing(Action<IDataReader, string[]> action, string fullFilePath = null)
        {
            try
            {
                if(action == null)
                {
                    _logger.LogWarning("LoadFileForProcessing action is null");
                    return;
                }

                _logger.LogInformation("LoadFileForProcessing Start");

                var _fp = fullFilePath ?? Path.Combine(_appSettings.FileArguments.FileLocation, _appSettings.FileArguments.File);

                _logger.LogInformation($"File Location: {_fp}");

                var FileExtension = Path.GetExtension(_fp);
                var Files = new[] { _fp };

                base.ProcessFiles((dr, columns) =>
                {
                    action.Invoke(dr,columns);

                }, Files);

                _logger.LogInformation("LoadFileForProcessing End");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured at LoadFileForProcessing {ex}");
                throw;
            }
        }
    }
}
