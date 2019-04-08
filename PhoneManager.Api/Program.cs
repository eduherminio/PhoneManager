using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PhoneManager.Api.Constants;

namespace PhoneManager.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IConfiguration configuration = GetConfiguration();

            Task publicApi = BuildWebHost(args, configuration, AppSettingsKeys.UrlConfigurationKey)
                .RunAsync();

            Task.WaitAll(publicApi);
        }

        private static IConfiguration GetConfiguration()
        {
            return AppSettingsHelpers.GetConfiguration();
        }

        public static IWebHost BuildWebHost(string[] args, IConfiguration configuration, string urlKey)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseKestrel()
                .UseConfiguration(configuration)
                .UseStartup<Startup>()
                .UseUrls(configuration[urlKey])
                .Build();
        }
    }
}
