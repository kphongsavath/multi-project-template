using AutoMapper;
using Microsoft.Extensions.Logging;
using $ext_safeprojectname$.Common.Configurations;

namespace $ext_safeprojectname$.DataAccess.Repository
{
    internal abstract class RepositoryBase<T>
    {
        protected readonly IMapper _mapper;
        protected readonly ILogger<T> _logger;

        protected readonly AppSettings _appSettings;

        protected RepositoryBase(AppSettings appSettings, IMapper mapper, ILogger<T> logger)
        {
            _appSettings = appSettings;
            _mapper = mapper;
            _logger = logger;
        }


    }
}
