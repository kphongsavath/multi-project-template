using Microsoft.Extensions.Logging;
using MiniExcelLibs;
using System.Data;
using $ext_safeprojectname$.Common.Configurations;
using $ext_safeprojectname$.Integration.Interfaces;

namespace $ext_safeprojectname$.Integration.Excel
{
    public abstract class BaseReader<T> : IFileReader
    {
        protected readonly AppSettings _appSettings;
        protected readonly ILogger<T> _logger;

        protected BaseReader(AppSettings appSettings, ILogger<T> logger)
        {
            _appSettings = appSettings;
            _logger = logger;
        }

        public virtual void ProcessFiles(Action<IDataReader, string[]> action, params string[] files)
        {

            ProcessFileContent(action, files);
        }

        //public virtual Task ProcessFilesAsync(Action<IDataReader, string[]> action, params string[] files)
        //{
        //    return ProcessFileContent(action,files);
        //}

        protected void ProcessFileContent(Action<IDataReader, string[]> action, params string[] files)
        {
            foreach (var file in files)
            {
                if (File.Exists(file))
                {
                    using var stream = File.OpenRead(file);
                    Enum.TryParse<ExcelType>(Path.GetExtension(stream.Name).Replace(".", string.Empty), true, out var excelType);

                    using var dr = new MiniExcelDataReader(stream, useHeaderRow: true,
                           excelType: excelType,
                           sheetName: string.IsNullOrEmpty(_appSettings.FileArguments.ExceltSheetName) ? null : _appSettings.FileArguments.ExceltSheetName);

                    if ((_appSettings.FileArguments.ColumnNames?.Length ?? 0) > 0)
                    {
                        action.Invoke(dr, _appSettings.FileArguments.ColumnNames);
                    }
                    else
                    {
                        var cols = stream.GetColumns(useHeaderRow: true,
                            excelType: excelType,
                            sheetName: string.IsNullOrEmpty(_appSettings.FileArguments.ExceltSheetName) ? null : _appSettings.FileArguments.ExceltSheetName);

                        action.Invoke(dr, cols.ToArray());
                    }
                }
                else
                {
                    _logger.LogWarning($"File does not exists:{file}");
                }
            }
        }

        protected void ExportFileContent<T>(IEnumerable<T> content, string FilePath)
        {
            MiniExcel.SaveAs(FilePath, content, excelType: ExcelType.XLSX, overwriteFile: true);
        }

    }
}
