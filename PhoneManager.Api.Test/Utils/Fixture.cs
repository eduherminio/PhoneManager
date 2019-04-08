using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;


namespace PhoneManager.Api.Test.Utils
{
    public class Fixture : IDisposable
    {
        public static readonly string DefaultString = "testUser";

        public readonly TestServer Server;

        public Fixture()
        {
            IConfiguration configuration = AppSettingsHelpers.GetConfiguration();
            configuration["url"] = "http://localhost:1234";
            Server = CreateTestServer<Startup>(configuration);
        }

        public HttpClient GetClient() => Server.CreateClient();

        public TService GetService<TService>()
        {
            return (TService)Server.Host.Services.GetRequiredService(typeof(TService));
        }

        private static TestServer CreateTestServer<TStartup>(IConfiguration configuration)
            where TStartup : class
        {
            var hostBuilder = new WebHostBuilder()
                .UseConfiguration(configuration)
                .UseStartup<TStartup>();

            return new TestServer(hostBuilder);
        }

        public Uri CreateUri(string str) => new Uri(str, UriKind.Relative);

        #region IDisposable implementation
        protected virtual void Dispose(bool disposing)
        {
            // Delete DB, if any
            Server.Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
