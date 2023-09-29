using Microsoft.Extensions.Logging;
using $ext_safeprojectname$.Common.Configurations;

namespace $ext_safeprojectname$.Integration.Services
{
    internal abstract class ServiceBase<T>
    {
        protected readonly AppSettings _appSettings;
        protected readonly ILogger<T> _logger;

        protected ServiceBase(AppSettings appSettings, ILogger<T> logger)
        {
            _appSettings = appSettings;
            _logger = logger;
        }
    }
}
