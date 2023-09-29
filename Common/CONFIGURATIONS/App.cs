namespace $ext_safeprojectname$.Common.Configurations
{
    public class App
    {
        public string Name { get; set; }
        public int RetryCount { get; set; }
        public int TimeoutAfter { get; set; }
        public int BatchTimeout { get; set; }
        public int BatchSize { get; set; }

    }
}
