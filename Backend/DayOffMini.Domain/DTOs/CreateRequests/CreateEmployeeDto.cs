namespace DayOffMini.Domain.DTOs.CreateRequests
{
    public class CreateEmployeeDto
    {
        public string Email { get; set; } = null!;
        public string? Name { get; set; }
        public string? Password { get; set; }
    }
}
