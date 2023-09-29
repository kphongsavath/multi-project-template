using System.Runtime.CompilerServices;

namespace $ext_safeprojectname$.DataAccess.Interfaces
{
    public interface IProcessRepository
    {
        IEnumerable<EF.Oracle.Entities.SapMara> Articles(string mpid, [CallerMemberName] string callerName = "");
        Task OracleBulkInsertAsync(EF.Oracle.Entities.SapMara[] bulkData);

        IEnumerable<EF.Sql.Entities.VsEpConfiguration> VsEpConfigurations([CallerMemberName] string callerName = "");
        IEnumerable<EF.Sql.Entities.VsEpConfiguration> VsEpConfigurationsBatch(int skip, int take, [CallerMemberName] string callerName = "");
        void SqlBulkCopyWithCollection(EF.Oracle.Entities.SapMara[] bulkData);
        int VsEpConfigurationsCount();
        IEnumerable<EF.Sql.Entities.ArticleData> ArticleDataBatch(int skip, int take);
        int ArticleDataCount();

    }
}
