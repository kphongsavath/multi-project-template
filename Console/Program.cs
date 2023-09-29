using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.Net.Http.Headers;
using System.Text;
using $ext_safeprojectname$.Business.Logic.Interfaces;
using $ext_safeprojectname$.Common.Configurations;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((hostingContext, config) =>
    {
        // reads mpa_api_key.json for GoogleJsonKey - Delete if not needed
        config.AddJsonFile("mpa_api_key.json");
    })
    .ConfigureServices((host, services) =>
    {
        IConfiguration configs = host.Configuration;

        var appSettings = new AppSettings();
        configs.Bind(appSettings);
        services.AddSingleton(appSettings);

        // Add GoogleJsonKey for GoogleStorage  - Delete if not needed
        var googleJsonKey = new GoogleJsonKey();
        configs.Bind(googleJsonKey);
        services.AddSingleton(googleJsonKey);


        // Add HttpClientFactory For KafkaApi  - Delete if not needed
        if (!string.IsNullOrEmpty(appSettings.KafkaApi.Url))
        {
            services.AddHttpClient((nameof(appSettings.KafkaApi)), c =>
            {
                c.BaseAddress = new Uri(appSettings.KafkaApi.Url);
                byte[] byteData = Encoding.ASCII.GetBytes($"{appSettings.KafkaApi.ApiUsername}:{appSettings.KafkaApi.ApiPassword}");
                c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteData));
            });
        }

        // Dependency Injection of Logic Layer
        $ext_safeprojectname$.Business.Logic.Configuration.DependencyConfig.Configure(services, appSettings);

    })
    .UseSerilog((host, config) =>
    {
        // reads appsettings.json for Serilog configuration
        // check logging level and customize
        config.ReadFrom.Configuration(host.Configuration);
    })
    .Build();


Log.Logger.Information("Started : Job");

var jobLogic = host.Services.GetService<IProcessLogic>();
jobLogic.ExecuteProcess();


Log.Logger.Information("Complete : Service - AllocationFeedService - ProcessAllocationsAsync()");
Log.Logger.Information("Application Processing Completed Successfully.");