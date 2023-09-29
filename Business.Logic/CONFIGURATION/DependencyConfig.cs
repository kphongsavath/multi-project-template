using Microsoft.Extensions.DependencyInjection;
using $ext_safeprojectname$.Business.Logic.Configuration.Mapper;
using $ext_safeprojectname$.Business.Logic.Interfaces;
using $ext_safeprojectname$.Business.Logic.Logic;
using $ext_safeprojectname$.Common.Configurations;

namespace $ext_safeprojectname$.Business.Logic.Configuration
{
    public class DependencyConfig
    {
        public static void Configure(IServiceCollection config, AppSettings appSetting)
        {
            //AutoMapper Config
            config.AddAutoMapper(cfg =>
            {
                  cfg.AddProfile<ArticleMapper>();
            });


            config.AddScoped<IProcessLogic, ProcessLogic>();


            // DI For other projects
            Integration.Configuration.DependencyConfig.Configure(config, appSetting);
            DataAccess.Configuration.DependencyConfig.Configure(config, appSetting);
        }
    }
}
