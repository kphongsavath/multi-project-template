namespace $ext_safeprojectname$.Common.Configurations
{
    public class ConnectionStrings
    {
        public string? MsSqlSalesInventoryConnection { get; set; }
        public string? OracleConnection { get; set; }
        public string? MpaSalesPlan { get; set; }
        public int Timeout { get; set; }
    }
}
