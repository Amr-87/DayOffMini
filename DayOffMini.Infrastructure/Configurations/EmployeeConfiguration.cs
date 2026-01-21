using DayOffMini.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DayOffMini.Infrastructure.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasData(
                     new Employee { Id = 1, Email = "amr@dayoffmini.com", Password = "Amr@123" },
                     new Employee { Id = 2, Email = "yasser@dayoffmini.com", Password = "Yasser@123" }
                     );
        }
    }
}
