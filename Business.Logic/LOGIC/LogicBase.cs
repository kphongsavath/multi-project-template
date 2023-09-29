using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;
using $ext_safeprojectname$.Common.Configurations;

namespace $ext_safeprojectname$.Business.Logic.Logic
{
    internal abstract class LogicBase<T>  
    {
        protected readonly AppSettings _appSettings;
        protected readonly ILogger<T> _logger;

        protected LogicBase(AppSettings appSettings, ILogger<T> logger)
        {
            _appSettings = appSettings;
            _logger = logger;
        }

        public void ExecuteProcess([CallerMemberName] string callerName = "")
        {
            _logger.LogInformation($"Starting ExecuteProcess: {DateTime.Now}");
            Process();
            _logger.LogInformation($"End ExecuteProcess: {DateTime.Now}");

        }

        //Override this method to implement the logic
        protected virtual void Process()
        {

        }
    }
}
