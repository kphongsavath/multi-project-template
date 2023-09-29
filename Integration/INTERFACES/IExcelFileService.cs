using System.Data;

namespace $ext_safeprojectname$.Integration.Interfaces
{
    public interface IExcelFileService
    {
        /// <summary>
        /// Export data to excel file
        /// </summary>
        /// <typeparam name="T">Data Type to export</typeparam>
        /// <param name="dataToExport">Data to export</param>
        /// <param name="exportFileLocation">file location to export to - Defaults to FileArguments.ExportFileLocation</param>
        /// <param name="exportFileName">file name - Defaults to FileArguments.ExportFile</param>
        void ExportToExcelFile<T>(IEnumerable<T> dataToExport, string exportFileLocation = null, string exportFileName = null);

        /// <summary>
        /// Loads excel/csv file for processing
        /// </summary>
        /// <param name="action">The action to perform when the file has loaded - data is in a IDataReader stream</param>
        /// <param name="fullFilePath">Full file path to file - Defaults to FileArguments.FileLocation + FileArguments.File</param>
        void LoadFileForProcessing(Action<IDataReader, string[]> action, string fullFilePath = null);
    }
}
