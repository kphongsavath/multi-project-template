using Microsoft.Extensions.Configuration;

namespace $ext_safeprojectname$.Common.Configurations
{
    public class LogLevel
    {
        public string Default { get; set; } = string.Empty;
        public string Microsoft { get; set; } = string.Empty;

        [ConfigurationKeyName("Microsoft.Hosting.Lifetime")]
        public string MicrosoftHostingLifetime { get; set; } = string.Empty;
    }
}
