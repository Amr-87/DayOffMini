using DayOffMini.Application.MappingProfiles;
using DayOffMini.Application.Policies.Implementations;
using DayOffMini.Application.Policies.Interfaces;
using DayOffMini.Application.Services;
using DayOffMini.Domain.Interfaces.IServices;
using Microsoft.Extensions.DependencyInjection;

namespace DayOffMini.Application
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(EmployeeMappingProfile).Assembly);

            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<ILeaveTypeService, LeaveTypeService>();
            services.AddScoped<ILeaveRequestStatusService, LeaveRequestStatusService>();
            services.AddScoped<ILeaveBalanceService, LeaveBalanceService>();
            services.AddScoped<ILeaveRequestService, LeaveRequestService>();

            services.AddScoped<IEmployeeLeavePolicy, DefaultEmployeeLeavePolicy>();

            return services;
        }
    }
}
