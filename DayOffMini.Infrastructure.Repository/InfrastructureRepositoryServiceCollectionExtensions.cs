using DayOffMini.Domain.Interfaces;
using DayOffMini.Infrastructure.Repository.Repositories.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace DayOffMini.Infrastructure.Repository
{
    public static class InfrastructureServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureRepositories(
            this IServiceCollection services)
        {

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return services;
        }
    }
}
