using AutoMapper.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using $ext_safeprojectname$.Common.Configurations;
using $ext_safeprojectname$.DataAccess.Configuration.AutoMapper;
using $ext_safeprojectname$.DataAccess.EF.Oracle.DbContext;
using $ext_safeprojectname$.DataAccess.EF.Sql.DbContext;
using $ext_safeprojectname$.DataAccess.Helper;
using $ext_safeprojectname$.DataAccess.Interfaces;
using $ext_safeprojectname$.DataAccess.Repository;

namespace $ext_safeprojectname$.DataAccess.Configuration
{
    public class DependencyConfig
    {
        public static void Configure(IServiceCollection config, AppSettings appSetting)
        {
            //AutoMapper Config
            config.AddAutoMapper(cfg =>
            {
                cfg.AddDataReaderProfile(new DataReaderProfile());
               // cfg.AddProfile<AurErosionProfiles>();
              //  cfg.AddProfile<MpaMasterProfiles>();
            });


            //config.AddDbContext<Oracle.DbContext.LinePlanContext>(options => options.UseOracle(appSetting.ConnectionStrings.Oracle_LinePlan));
            if (!string.IsNullOrEmpty(appSetting.ConnectionStrings?.OracleConnection ?? string.Empty))
            {
                config.AddDbContextFactory<OracleDbContext>(
                   options => options.UseOracle(appSetting.ConnectionStrings.OracleConnection));
            }

            // EF Sql Database Contexts
            if (!string.IsNullOrEmpty(appSetting.ConnectionStrings?.MsSqlSalesInventoryConnection ?? string.Empty))
            {
                config.AddDbContextFactory<SqlDbContext>(
                   options => options.UseSqlServer(appSetting.ConnectionStrings.MsSqlSalesInventoryConnection ?? string.Empty));
            }

            config.AddTransient<IOracleHelper, OracleHelper>();
            config.AddTransient<ISqlHelper, SqlHelper>();

            config.AddTransient<IProcessRepository, ProcessRepository>();

        }
    }
}
