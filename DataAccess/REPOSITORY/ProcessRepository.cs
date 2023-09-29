using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Runtime.CompilerServices;
using $ext_safeprojectname$.Common.Configurations;
using $ext_safeprojectname$.DataAccess.EF.Oracle.DbContext;
using $ext_safeprojectname$.DataAccess.EF.Sql.DbContext;
using $ext_safeprojectname$.DataAccess.Interfaces;

namespace $ext_safeprojectname$.DataAccess.Repository
{
    internal class ProcessRepository : RepositoryBase<IProcessRepository>, IProcessRepository
    {

        private readonly IDbContextFactory<SqlDbContext> _sqlDbContext;
        private readonly IDbContextFactory<OracleDbContext> _oracleDbContext;
        private readonly IOracleHelper _oracleHelper;
        private readonly ISqlHelper _sqlHelper;

        public ProcessRepository(
            IDbContextFactory<OracleDbContext> oracleDbContext,
            IDbContextFactory<SqlDbContext> sqlDbContext,
            AppSettings appSettings, ILogger<IProcessRepository> logger, IMapper mapper, IOracleHelper oracleHelper, ISqlHelper sqlHelper)
            : base(appSettings, mapper, logger)
        {
            _oracleDbContext = oracleDbContext;
            _sqlDbContext = sqlDbContext;
            _oracleHelper = oracleHelper;
            _sqlHelper = sqlHelper;
        }

        public IEnumerable<EF.Oracle.Entities.SapMara> Articles(string mpid, [CallerMemberName] string callerName = "")
        {
            using var dbContext = _oracleDbContext.CreateDbContext();

            return dbContext.SapMara.Where(m => (m.ZzChoiceid ?? "").Trim() == mpid.Trim()).ToArray();

        }

        public void SqlBulkInsertWithDataReader()
        {
            _oracleHelper.ExecuteOracleStoredProcedure("PKG.SOMETHING", (dataReader) =>
            {
                _sqlHelper.SqlBulkInsert(dataReader, "Inbound.SapMara", _appSettings.ConnectionStrings.MsSqlSalesInventoryConnection, "Prdha", "Matnr", "ZzChoice");
            }, _appSettings.ConnectionStrings.OracleConnection);
        }
        public void SqlBulkCopyWithCollection(EF.Oracle.Entities.SapMara[] bulkData)
        {
            using var conn = new SqlConnection(_appSettings.ConnectionStrings.MsSqlSalesInventoryConnection);
            // Create a DataTable to hold the data
            DataTable dataTable = new DataTable();

            // Assuming 'myObjects' is an array of objects and the properties match the table columns
            foreach (var obj in bulkData)
            {
                // Assuming the object properties match the table columns
                DataRow row = dataTable.NewRow();
                row["PRDHA"] = obj.Prdha;
                row["MATNR"] = obj.Matnr;
                row["ZZCHOICE"] = obj.ZzChoice;
                // Add more columns as needed

                dataTable.Rows.Add(row);
            }
            conn.Open();
            using var bulk = new SqlBulkCopy(conn)
            {
                BulkCopyTimeout = _appSettings.ConnectionStrings.Timeout,
                BatchSize = _appSettings.App.BatchSize,
                DestinationTableName = "[Inbound].[SapMara]"
            };

            bulk.ColumnMappings.Add("PRDHA", "Prdha");
            bulk.ColumnMappings.Add("MATNR", "Matnr");
            bulk.ColumnMappings.Add("ZZCHOICE", "ZzChoice");

            bulk.WriteToServer(dataTable);
            bulk.Close();
        }
        public async Task OracleBulkInsertAsync(EF.Oracle.Entities.SapMara[] bulkData)
        {
            try
            {
                using (var connection = new OracleConnection(_appSettings.ConnectionStrings.OracleConnection))
                {
                    await connection.OpenAsync();

                    var bulkDataCount = bulkData.Count();
                    var prdhaNames = new string[bulkDataCount];
                    var matnrNames = new string[bulkDataCount];
                    var choices = new string[bulkDataCount];

                    for (int j = 0; j < bulkDataCount; j++)
                    {
                        prdhaNames[j] = bulkData[j].Prdha;
                        matnrNames[j] = bulkData[j].Matnr;
                        choices[j] = bulkData[j].ZzChoice;
                    }


                    // create command and set properties
                    OracleCommand cmd = connection.CreateCommand();
                    cmd.CommandTimeout = _appSettings.ConnectionStrings.Timeout;
                    cmd.CommandText = "INSERT INTO MPA_MASTER.ZZ_SAPMARA (PRDHA, MATNR, ZZCHOICE) VALUES (:1, :2, :3)";
                    cmd.ArrayBindCount = bulkDataCount;
                    cmd.Parameters.Add("PRDHA", OracleDbType.Varchar2).Value = prdhaNames;
                    cmd.Parameters.Add("MATNR", OracleDbType.Varchar2).Value = matnrNames;
                    cmd.Parameters.Add("ZZCHOICE", OracleDbType.Varchar2).Value = matnrNames;
                    await cmd.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public IEnumerable<EF.Sql.Entities.VsEpConfiguration> VsEpConfigurations([CallerMemberName] string callerName = "")
        {
            using var dbContext = _sqlDbContext.CreateDbContext();
            return dbContext.VsEpConfiguration.ToArray();
        }
        public IEnumerable<EF.Sql.Entities.VsEpConfiguration> VsEpConfigurationsBatch(int skip, int take, [CallerMemberName] string callerName = "")
        {
            using var dbContext = _sqlDbContext.CreateDbContext();
            return dbContext.VsEpConfiguration.OrderBy(o => o.Id).Skip(skip).Take(take).ToArray();
        }
        public int VsEpConfigurationsCount()
        {
            using var dbContext = _sqlDbContext.CreateDbContext();
            return dbContext.VsEpConfiguration.Count();
        }

        public IEnumerable<EF.Sql.Entities.ArticleData> ArticleDataBatch(int skip, int take)
        {
            using var dbContext = _sqlDbContext.CreateDbContext();
            return dbContext.ArticleData.OrderBy(o => o.Id).Skip(skip).Take(take).ToArray();
        }

        public int ArticleDataCount()
        {
            using var dbContext = _sqlDbContext.CreateDbContext();
            return dbContext.ArticleData.Count();
        }
    }
}
