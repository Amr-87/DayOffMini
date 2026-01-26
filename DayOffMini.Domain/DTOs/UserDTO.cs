using System.ComponentModel.DataAnnotations;

namespace DayOffMini.Domain.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string? Name { get; set; }

        [MaxLength(256)]
        public string? Email { get; set; }

        [MaxLength(20)]
        public string? PhoneNumber { get; set; }

    }
}
