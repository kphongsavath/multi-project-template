using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Data.Common;
using $ext_safeprojectname$.Common.Configurations;
using $ext_safeprojectname$.DataAccess.EF;
using $ext_safeprojectname$.DataAccess.Interfaces;
using $ext_safeprojectname$.DataAccess.Repository;

namespace $ext_safeprojectname$.DataAccess.Helper
{
    internal class SqlHelper : RepositoryBase<ISqlHelper>, ISqlHelper
    {
        public SqlHelper(AppSettings appSettings, IMapper mapper, ILogger<ISqlHelper> logger) : base(appSettings, mapper, logger)
        {
        }

        public void ExecuteSqlStoredProcedure(IDbContextFactory<DbContextBase> dbContext, string storedProcedureName, params DbParameter[] dbParameters)
        {
            _logger.LogInformation($"Starting ExecuteSqlStoredProcedure {storedProcedureName}: {DateTime.Now}");
            using var dbcontext = dbContext.CreateDbContext();
            using var conn = dbcontext.Database.GetDbConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = storedProcedureName;

            if ((dbParameters?.Length ?? 0) > 0)
            {
                cmd.Parameters.AddRange(dbParameters);
            }

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _logger.LogInformation($"Finished ExecuteSqlStoredProcedure {storedProcedureName}: {DateTime.Now}");

                conn.Close();
            }
        }
        public void ExecuteSqlQuery(IDbContextFactory<DbContextBase> dbContext, string query)
        {
            _logger.LogInformation($"Starting ExecuteSqlQuery {DateTime.Now}");

            using var dbcontext = dbContext.CreateDbContext();
            using var conn = dbcontext.Database.GetDbConnection();
            var cmd = conn.CreateCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _logger.LogInformation($"Finished ExecuteSqlQuery {DateTime.Now}");

                conn.Close();
            }
        }
        public async Task<IEnumerable<TResult>> ExecuteSqlStoredProcedureAsync<TResult>(DbContextBase dbContext, string storedProcedureName, Func<IDataReader, IEnumerable<TResult>> iDataReaderFunction, params DbParameter[] dbParameters)
        {
            _logger.LogInformation($"Starting ExecuteSqlStoredProcedureAsync {storedProcedureName} {DateTime.Now}");

            using var conn = dbContext.Database.GetDbConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = storedProcedureName;

            if ((dbParameters?.Count() ?? 0) > 0)
            {
                cmd.Parameters.AddRange(dbParameters);
            }
            try
            {
                conn.Open();

                using var objReader = await cmd.ExecuteReaderAsync();
                if (iDataReaderFunction != null)
                {
                    var result = iDataReaderFunction.Invoke(objReader);
                    conn.Close();
                    return result;
                }
                return default;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _logger.LogInformation($"Finised ExecuteSqlStoredProcedureAsync {storedProcedureName} {DateTime.Now}");

                conn.Close();
            }
        }
        public void ExecuteSqlStoredProcedure(IDbContextFactory<DbContextBase> dbContext, string storedProcedureName, Action<IDataReader> iDataReaderFunction, params DbParameter[] dbParameters)
        {
            _logger.LogInformation($"Starting ExecuteSqlStoredProcedure: {storedProcedureName} {DateTime.Now}");
            using var dbcontext = dbContext.CreateDbContext();
            using var conn = dbcontext.Database.GetDbConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = storedProcedureName;

            if ((dbParameters?.Count() ?? 0) > 0)
            {
                cmd.Parameters.AddRange(dbParameters);
            }
            try
            {
                conn.Open();

                using var objReader = cmd.ExecuteReader();
                if (iDataReaderFunction != null)
                {
                    iDataReaderFunction.Invoke(objReader);
                    conn.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _logger.LogInformation($"Finised ExecuteSqlStoredProcedure: {storedProcedureName} {DateTime.Now}");
                conn.Close();
            }
        }
        public void SqlBulkInsert(IDataReader dataReader, string destinationTable, string connectionString, params string[] columnNames)
        {
            SqlBulkInsertAsync(dataReader,destinationTable, connectionString, columnNames).GetAwaiter().GetResult();

        }
        public async Task SqlBulkInsertAsync(IDataReader dataReader, string destinationTable, string connectionString, params string[] columnNames)
        {
            using var bulk = ConfigureSqlBulkCopy(destinationTable, connectionString, columnNames);
            await bulk.WriteToServerAsync(dataReader);

        }
        /// <summary>
        /// Configure SqlBulkCopy
        /// </summary>
        /// <param name="destinationTable">Destination Sql Table </param>
        /// <param name="connectionString">Connectionstring to SQL Database</param>
        /// <param name="columnNames">column names in ordinal order of destination table</param>
        /// <returns> SqlBulkCopy Object</returns>
        public SqlBulkCopy ConfigureSqlBulkCopy(string destinationTable, string connectionString, params string[] columnNames)
        {
            var bulk = new SqlBulkCopy(connectionString)
            {
                EnableStreaming = true,
                BatchSize = _appSettings.App.BatchSize,
                BulkCopyTimeout = 0,
                DestinationTableName = destinationTable
            };
            for (int i = 0; i < columnNames.Length; i++)
            {
                bulk.ColumnMappings.Add(i, columnNames[i]);
            }
            return bulk;
        }
    }
}
