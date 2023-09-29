using Microsoft.Extensions.Configuration;

namespace $ext_safeprojectname$.Common.Configurations
{
    public class SerilogConfig
    {
        public string MinimumLevel { get; set; }
        public Override Override { get; set; }
        public List<WriteTo> WriteTo { get; set; }
        public List<string> Enrich { get; set; }
    }

    public class Args
    {
        public string OutputTemplate { get; set; }
        public string Path { get; set; }
        public string RollingInterval { get; set; }
    }

    public class Override
    {
        [ConfigurationKeyName("Microsoft.AspNetCore")]
        public string MicrosoftAspNetCore { get; set; }
    }

    public class WriteTo
    {
        public string Name { get; set; }
        public Args Args { get; set; }
    }
}
