using System;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhoneManager.Api.Swagger;

namespace PhoneManager.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        private static readonly ApiVersion _apiVersion = new ApiVersion(1, 0);

        private ApiInfo _apiInfo => new ApiInfo(
            "PhoneManager API",
            "API for managing phones",
            _apiVersion);

        private string _swaggerDocumentVersion { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _swaggerDocumentVersion = $"v{_apiInfo.ApiVersion}";
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationInsightsTelemetry(Configuration);
            services.AddOptions();

            // Api versioning
            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = _apiInfo.ApiVersion;
            });

            // Swagger
            string assemblyName = GetType().GetTypeInfo().Assembly.GetName().Name;
            services.ConfigureSwaggerMvcServices(_swaggerDocumentVersion, _apiInfo, assemblyName);

            services.AddAuthenticationCore();
            services.AddAuthorizationPolicyEvaluator();

            services.AddMvcCore().AddApiExplorer();
            services.AddMvc();

            return services.BuildServiceProvider();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.ConfigureSwaggerMvc(_swaggerDocumentVersion);

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
