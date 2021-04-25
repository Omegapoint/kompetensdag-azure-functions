﻿using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Omegapoint.Functions;
using System.IO;

[assembly: FunctionsStartup(typeof(Startup))]

namespace Omegapoint.Functions
{
    public class Startup : FunctionsStartup
    {

        public override void Configure(IFunctionsHostBuilder builder)
        {
            ConfigureServices(builder.Services).BuildServiceProvider(true);
        }

        private IServiceCollection ConfigureServices(IServiceCollection services)
        {
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddEnvironmentVariables();

            var localSettings = GetLocalSettings();

            configBuilder.AddConfiguration(localSettings);

            var config = configBuilder.Build();
            services
                .AddSingleton<IConfiguration>(config)
                .AddHttpClient();
            return services;
        }

        private static IConfigurationSection GetLocalSettings()
        {
            var localConfigBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true);

            var localSettings = localConfigBuilder.Build().GetSection("Values");
            return localSettings;
        }
    }
}

