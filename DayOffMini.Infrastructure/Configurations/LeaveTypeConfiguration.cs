using DayOffMini.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DayOffMini.Infrastructure.Configurations
{
    public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
    {
        public void Configure(EntityTypeBuilder<LeaveType> builder)
        {
            builder.HasData(
                       new LeaveType { Id = 1, Name = "Schedual", IsDefault = true, DaysOffBalance = 14 },
                       new LeaveType { Id = 2, Name = "Casual", IsDefault = true, DaysOffBalance = 7 }
                   );
        }
    }
}
