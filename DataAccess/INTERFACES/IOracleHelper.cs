using Oracle.ManagedDataAccess.Client;
using System.Data;
using $ext_safeprojectname$.Common.Configurations;

namespace $ext_safeprojectname$.DataAccess.Interfaces
{
    internal interface IOracleHelper
    {
        DataTable ExecuteOracleStoredProcedure(string storedProcName,string connectionString = null);
        DataTable ExecuteOracleStoredProcedure(string storedProcName, string connectionString = null, params OracleParameter[] oracleParameter);
        IEnumerable<Z> ExecuteOracleStoredProcedure<Z>(string storedProcName, Func<IDataReader, IEnumerable<Z>> func, string connectionString = null, params OracleParameter[] oracleParameter);
        void ExecuteOracleStoredProcedure(string storedProcName, Action<IDataReader> func, string connectionString = null, params OracleParameter[] oracleParameter);
        void ExecuteOracleQuery(string query, Action<IDataReader> func, string? connectionString = null);
        IEnumerable<Z> ExecuteOracleQuery<Z>(string query, Func<IDataReader, IEnumerable<Z>> func, string? connectionString = null);
        void ExecuteOracleQuery(string query, string? connectionString = null);
        void ExecuteOracleInsert(string insertStatement, int arrayBindCount, string? connectionString = null, params OracleParameter[] oracleParameter);
    }
}
