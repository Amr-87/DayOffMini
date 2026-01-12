using DayOffMini.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DayOffMini.Infrastructure.UnitOfWork
{
    public static class InfrastructureUOWServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureUOW(
            this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();

            return services;
        }
    }
}
