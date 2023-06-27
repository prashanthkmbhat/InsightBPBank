using Microsoft.Extensions.DependencyInjection;
using ConsumerDataStandards.Core.Contracts;
using ConsumerDataStandards.Infrastructure.Repository;

namespace ConsumerDataStandards.Infrastructure.IoC
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddTransient<IBankingProductRepository, BankingProductRepository>();
        }
    }
}
