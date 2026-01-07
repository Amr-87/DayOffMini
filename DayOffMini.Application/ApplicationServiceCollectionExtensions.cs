using DayOffMini.Application.MappingProfiles;
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

            return services;
        }
    }
}
