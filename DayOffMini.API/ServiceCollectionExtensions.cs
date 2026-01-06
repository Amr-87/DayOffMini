using DayOffMini.Application.MappingProfiles;
using DayOffMini.Application.Services;
using DayOffMini.Domain.Interfaces;
using DayOffMini.Domain.Interfaces.IRepositories;
using DayOffMini.Domain.Interfaces.IServices;
using DayOffMini.Infrastructure.DbContext;
using DayOffMini.Infrastructure.Repository.Repositories.Generic;
using DayOffMini.Infrastructure.Repository.Repositories.Implementations;
using DayOffMini.Infrastructure.UnitOfWork.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace DayOffMini.API
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper(typeof(EmployeeMappingProfile).Assembly);

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeService, EmployeeService>();

            services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
            services.AddScoped<ILeaveTypeService, LeaveTypeService>();

            services.AddScoped<ILeaveRequestStatusRepository, LeaveRequestStatusRepository>();
            services.AddScoped<ILeaveRequestStatusService, LeaveRequestStatusService>();

            return services;
        }
    }
}
