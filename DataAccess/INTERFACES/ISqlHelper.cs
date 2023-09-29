using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.Common;
using $ext_safeprojectname$.DataAccess.EF;

namespace $ext_safeprojectname$.DataAccess.Interfaces
{
    public interface ISqlHelper
    {
        void ExecuteSqlStoredProcedure(IDbContextFactory<DbContextBase> dbContext, string storedProcedureName, params DbParameter[] dbParameters);
        void ExecuteSqlQuery(IDbContextFactory<DbContextBase> dbContext, string query);
        Task<IEnumerable<TResult>> ExecuteSqlStoredProcedureAsync<TResult>(DbContextBase dbContext, string storedProcedureName, Func<IDataReader, IEnumerable<TResult>> iDataReaderFunction, params DbParameter[] dbParameters);
        void ExecuteSqlStoredProcedure(IDbContextFactory<DbContextBase> dbContext, string storedProcedureName, Action<IDataReader> iDataReaderFunction, params DbParameter[] dbParameters);
        void SqlBulkInsert(IDataReader dataReader, string destinationTable, string connectionString, params string[] columnNames);
        Task SqlBulkInsertAsync(IDataReader dataReader, string destinationTable, string connectionString, params string[] columnNames);

        /// <summary>
        /// Configure SqlBulkCopy
        /// </summary>
        /// <param name="destinationTable">Destination Sql Table </param>
        /// <param name="connectionString">Connectionstring to SQL Database</param>
        /// <param name="columnNames">column names in ordinal order of destination table</param>
        /// <returns> SqlBulkCopy Object</returns>
        SqlBulkCopy ConfigureSqlBulkCopy(string destinationTable, string connectionString, params string[] columnNames);
    }
}
