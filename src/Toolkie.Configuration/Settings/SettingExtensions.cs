using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Hosting;

namespace Toolkie.Configuration.Settings
{
    public static class SettingExtensions
    {
        public static IWebHostBuilder UseToolkieConfiguration(this IWebHostBuilder webHostBuilder, string[] args)
        {
            return webHostBuilder.ConfigureAppConfiguration((hostingContext, config) =>
            {
                config.AddAppSettings(hostingContext.HostingEnvironment);
                config.AddUserSecrets(hostingContext.HostingEnvironment);
                config.AddEnvironmentVariables();
                config.AddCommandArguments(args);

                config.DisableReloading();
            });
        }

        private static void AddAppSettings(this IConfigurationBuilder config, IWebHostEnvironment hostingEnvironment)
        {
            var environmentName = hostingEnvironment.EnvironmentName;

            config.AddJsonFile($"appsettings.json", true, true)
                .AddJsonFile($"appsettings.{environmentName}.json", true, true);
        }

        private static void AddUserSecrets(this IConfigurationBuilder config, IWebHostEnvironment hostingEnvironment)
        {
            if (hostingEnvironment.IsDevelopment()) // different providers in dev
            {
                var appAssembly = Assembly.Load(new AssemblyName(hostingEnvironment.ApplicationName));
                if (appAssembly != null)
                {
                    config.AddUserSecrets(appAssembly, optional: true);
                }
            }
        }

        private static void AddCommandArguments(this IConfigurationBuilder configuration, string[] args)
        {
            if (args != null)
            {
                configuration.AddCommandLine(args);
            }
        }

        private static void DisableReloading(this IConfigurationBuilder configuration)
        {
            foreach (var source in configuration.Sources)
            {
                if (source is JsonConfigurationSource jsonSource)
                {
                    jsonSource.ReloadOnChange = false;
                }
            }
        }
    }
}
