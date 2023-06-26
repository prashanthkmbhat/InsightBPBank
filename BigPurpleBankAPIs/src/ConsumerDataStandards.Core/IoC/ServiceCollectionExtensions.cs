using Microsoft.Extensions.DependencyInjection;
using ConsumerDataStandards.Core.Contracts;
using ConsumerDataStandards.Core.Services;

namespace ConsumerDataStandards.Core.IoC
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCoreServices(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddTransient<IBankingProductService, BankingProductService>();
        }
    }
}
