namespace DayOffMini.Application.DTOs
{
    public class EmployeeDto
    {
        public int Id { get; set; }

        public string Email { get; set; } = null!;
        public string? Name { get; set; }
        public string? Password { get; set; }

    }
}
