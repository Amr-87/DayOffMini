namespace DayOffMini.Controllers.DTOs
{
    public class RegisterUserDto
    {
        public int RoleId { get; set; }

        public string Email { get; set; } = null!;
        public string Name { get; set; } = string.Empty;
        public string Password { get; set; } = null!;
    }
}
