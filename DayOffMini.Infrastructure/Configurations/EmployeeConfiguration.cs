using DayOffMini.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DayOffMini.Infrastructure.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            var hash1 = "$2a$11$ze1.ANcBDNd3JeiszbxXm.DUaGD8aHVo.U0IArbXCle0NgFUe/cMq";
            var hash2 = "$2a$11$SgFz/Vihqbwx4TRv3DIg5u1spJkYg.9voSzAaScIa3.Ao77H809n2";

            builder.HasData(
                     new Employee { Id = 1, Email = "amr@dayoffmini.com", Password = hash1 },
                     new Employee { Id = 2, Email = "yasser@dayoffmini.com", Password = hash2 }
                     );
        }
    }
}
