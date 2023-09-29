using AutoMapper;
using Microsoft.Extensions.Logging;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using $ext_safeprojectname$.Common.Configurations;
using $ext_safeprojectname$.DataAccess.Interfaces;
using $ext_safeprojectname$.DataAccess.Repository;

namespace $ext_safeprojectname$.DataAccess.Helper
{
    internal class OracleHelper : RepositoryBase<IOracleHelper>, IOracleHelper
    {
        public OracleHelper(AppSettings appSettings, IMapper mapper, ILogger<IOracleHelper> logger) : base(appSettings, mapper, logger)
        {
        }

        public DataTable ExecuteOracleStoredProcedure(string storedProcName, string connectionString = null)
        {
            if (!string.IsNullOrEmpty(storedProcName))
            {

                using var OConn = new OracleConnection(connectionString ?? _appSettings.ConnectionStrings.OracleConnection);
                using var OCommand = new OracleCommand
                {
                    Connection = OConn,
                    CommandText = storedProcName,
                    CommandType = CommandType.StoredProcedure
                };
                try
                {
                    _logger.LogInformation($"Executing {storedProcName}");
                    OConn.Open();
                    using var objReader = OCommand.ExecuteReader();
                    var dt = new DataTable();
                    dt.Load(objReader);
                    OConn.Close();
                    _logger.LogInformation($"Finished Executing {storedProcName}");

                    return dt;
                }
                catch (Exception)
                {

                    OConn.Close();
                    throw;
                }
            }
            return default;
        }
        public void ExecuteOracleStoredProcedure(string storedProcName, Action<IDataReader> func, string connectionString = null, params OracleParameter[] oracleParameter)
        {
            if (!string.IsNullOrEmpty(storedProcName))
            {
                using var OConn = new OracleConnection(connectionString ?? _appSettings.ConnectionStrings.OracleConnection);
                using var OCommand = new OracleCommand
                {
                    Connection = OConn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = storedProcName
                };

                if ((oracleParameter?.Length ?? 0) > 0)
                {
                    OCommand.Parameters.AddRange(oracleParameter);
                }
                try
                {
                    OConn.Open();
                    _logger.LogInformation($"Executing {storedProcName}");

                    using var objReader = OCommand.ExecuteReader();
                    if (func != null)
                    {
                        func.Invoke(objReader);
                        _logger.LogInformation($"Finished Executing {storedProcName}");

                        OConn.Close();
                    }
                }
                catch (Exception ex)
                {
                    OConn.Close();
                    throw;
                }
            }
        }
        public IEnumerable<Z> ExecuteOracleStoredProcedure<Z>(string storedProcName, Func<IDataReader, IEnumerable<Z>> func, string connectionString = null, params OracleParameter[] oracleParameter)
        {
            if (!string.IsNullOrEmpty(storedProcName))
            {
                using var OConn = new OracleConnection(connectionString ?? _appSettings.ConnectionStrings.OracleConnection);
                using var OCommand = new OracleCommand
                {
                    Connection = OConn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = storedProcName
                };

                if ((oracleParameter?.Length ?? 0) > 0)
                {
                    OCommand.Parameters.AddRange(oracleParameter);
                }
                try
                {
                    OConn.Open();
                    _logger.LogInformation($"Executing {storedProcName}");

                    using var objReader = OCommand.ExecuteReader();
                    if (func != null)
                    {
                        var result = func.Invoke(objReader);
                        OConn.Close();
                        _logger.LogInformation($"Finished Executing {storedProcName}");

                        return result;
                    }
                    return default;
                }
                catch (Exception)
                {
                    OConn.Close();
                    throw;
                }
            }
            return default;
        }
        public DataTable ExecuteOracleStoredProcedure(string storedProcName, string connectionString = null, params OracleParameter[] oracleParameter)
        {
            if (!string.IsNullOrEmpty(storedProcName))
            {
                using var OConn = new OracleConnection(connectionString ?? _appSettings.ConnectionStrings.OracleConnection);
                using var OCommand = new OracleCommand
                {
                    Connection = OConn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = storedProcName
                };

                if ((oracleParameter?.Length ?? 0) > 0)
                {
                    OCommand.Parameters.AddRange(oracleParameter);
                }
                try
                {
                    OConn.Open();
                    using var objReader = OCommand.ExecuteReader();
                    var dt = new DataTable();
                    dt.Load(objReader);
                    OConn.Close();
                    return dt;
                }
                catch (Exception)
                {
                    OConn.Close();
                    throw;
                }
            }
            return default;
        }

        public IEnumerable<Z> ExecuteOracleQuery<Z>(string query, Func<IDataReader, IEnumerable<Z>> func, string? connectionString = null)
        {
            if (!string.IsNullOrEmpty(query))
            {
                using var OConn = new OracleConnection(connectionString ?? connectionString ?? _appSettings.ConnectionStrings.OracleConnection);
                using var OCommand = new OracleCommand
                {
                    Connection = OConn,
                    CommandType = CommandType.Text,
                    CommandText = query
                };
                try
                {
                    OConn.Open();
                    _logger.LogInformation($"Executing {query}");

                    using var objReader = OCommand.ExecuteReader();
                    if (func != null)
                    {
                        var result = func.Invoke(objReader);
                        OConn.Close();
                        _logger.LogInformation($"Finished Executing {query}");
                        return result;
                    }
                }
                catch (Exception)
                {
                    OConn.Close();
                    throw;
                }
            }
            return default;

        }
        public void ExecuteOracleQuery(string query, Action<IDataReader> func, string? connectionString = null)
        {
            if (!string.IsNullOrEmpty(query))
            {
                using var OConn = new OracleConnection(connectionString ?? connectionString ?? _appSettings.ConnectionStrings.OracleConnection);
                using var OCommand = new OracleCommand
                {
                    Connection = OConn,
                    CommandType = CommandType.Text,
                    CommandText = query
                };
                try
                {
                    OConn.Open();
                    _logger.LogInformation($"Executing {query}");

                    using var objReader = OCommand.ExecuteReader();
                    if (func != null)
                    {
                        func.Invoke(objReader);
                        _logger.LogInformation($"Finished Executing {query}");

                        OConn.Close();
                    }
                }
                catch (Exception)
                {
                    OConn.Close();
                    throw;
                }
            }
        }
        public void ExecuteOracleQuery(string query, string? connectionString = null)
        {
            if (!string.IsNullOrEmpty(query))
            {
                using var OConn = new OracleConnection(connectionString ?? connectionString ?? _appSettings.ConnectionStrings.OracleConnection);
                using var OCommand = new OracleCommand
                {
                    Connection = OConn,
                    CommandType = CommandType.Text,
                    CommandText = query
                };
                try
                {
                    OConn.Open();
                    _logger.LogInformation($"Executing {query}");

                    OCommand.ExecuteNonQuery();

                    OConn.Close();
                }
                catch (Exception)
                {
                    OConn.Close();
                    throw;
                }
            }
        }

        public void ExecuteOracleInsert(string insertStatement, int arrayBindCount, string? connectionString = null, params OracleParameter[] oracleParameter)
        {

            if (!string.IsNullOrEmpty(insertStatement))
            {
                using var OConn = new OracleConnection(connectionString ?? connectionString ?? _appSettings.ConnectionStrings.OracleConnection);
                using var OCommand = new OracleCommand
                {
                    Connection = OConn,
                    CommandType = CommandType.Text,
                    CommandText = insertStatement
                };

                if ((oracleParameter?.Length ?? 0) > 0)
                {
                    OCommand.ArrayBindCount = arrayBindCount;
                    OCommand.Parameters.AddRange(oracleParameter);
                }
                try
                {
                    OConn.Open();
                    _logger.LogInformation($"Executing {insertStatement}");

                    OCommand.ExecuteNonQuery();

                    OConn.Close();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                    OConn.Close();
                    throw;
                }
            }

        }

    }
}
