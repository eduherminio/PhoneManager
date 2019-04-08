using Microsoft.Extensions.DependencyInjection;
using PhoneManager.Service;
using PhoneManager.Service.Impl;

namespace PhoneManager
{
    public static class ServiceCollectionExtensions
    {
        public static void AddPhoneManagerServices(this IServiceCollection services)
        {
            services.AddScoped<IPhoneNumberManager, PhoneNumberManager>();
            services.AddSingleton<IDbService, FakeDbService>();
        }
    }
}
