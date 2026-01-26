using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DayOffMini.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            string hash1 = "$2a$11$ze1.ANcBDNd3JeiszbxXm.DUaGD8aHVo.U0IArbXCle0NgFUe/cMq";
            string hash2 = "$2a$11$SgFz/Vihqbwx4TRv3DIg5u1spJkYg.9voSzAaScIa3.Ao77H809n2";

            builder.HasData(
                     new User { Id = 1, Email = "amr@dayoffmini.com", PhoneNumber = "01117699486", PasswordHash = hash1 },
                     new User { Id = 2, Email = "yasser@dayoffmini.com", PasswordHash = hash2 }
                     );
        }
    }
}
