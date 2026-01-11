namespace DayOffMini.Domain.DTOs
{
    public class UpdateEmployeeDto
    {
        public string Email { get; set; } = null!;
        public string? Name { get; set; }
        public string? Password { get; set; }
    }
}
