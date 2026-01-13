using DayOffMini.Domain.Interfaces;
using DayOffMini.Domain.Interfaces.IRepositories;
using DayOffMini.Infrastructure.Repository.Repositories;
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
            services.AddScoped<ILeaveBalanceReportRepository, LeaveBalanceReportRepository>();
            services.AddScoped<ILeaveBalanceRepository, LeaveBalanceRepository>();
            services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();

            return services;
        }
    }
}
