using Microsoft.Extensions.DependencyInjection;
using $ext_safeprojectname$.Common.Configurations;
using $ext_safeprojectname$.Integration.Interfaces;
using $ext_safeprojectname$.Integration.Services;

namespace $ext_safeprojectname$.Integration.Configuration
{
    public class DependencyConfig
    {
        public static void Configure(IServiceCollection config, AppSettings appSetting)
        {
            config.AddTransient<IEmailService, EmailService>();
            config.AddTransient<IKafkaService, KafkaService>();
            config.AddTransient<IExcelFileService, ExcelFileService>();
            config.AddTransient<IGoogleStorage, GoogleStorage>();

        }
    }
}
