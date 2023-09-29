using System.Data;

namespace $ext_safeprojectname$.Integration.Interfaces
{
    public interface IFileReader
    {
        // Task ProcessFilesAsync(Func<IDataReader, string[], Task> action,params string[] files);
        void ProcessFiles(Action<IDataReader, string[]> action, params string[] files);
    }
}
