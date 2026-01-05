using DayOffMini.Application.Mapping.Implementations;
using DayOffMini.Application.Mapping.Interfaces;
using DayOffMini.Application.Services;
using DayOffMini.Application.Services.Interfaces;
using DayOffMini.Domain.Interfaces;
using DayOffMini.Domain.Interfaces.Repositories;
using DayOffMini.Infrastructure.DbContext;
using DayOffMini.Infrastructure.Repositories.Generic;
using DayOffMini.Infrastructure.Repositories.Implementations;
using DayOffMini.Persistence.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace DayOffMini.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            // Add services to the container.
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });

            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IEmployeeMapper, EmployeeMapper>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();

            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
