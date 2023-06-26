using Microsoft.Extensions.DependencyInjection;
using ConsumerDataStandards.Core.Contracts; 

namespace ConsumerDataStandards.Infrastructure.IoC
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrasturctureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddTransient<IBankingProductRepository, BankingProductRepository>();
        }
    }
}
