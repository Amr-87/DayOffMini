using System.ComponentModel.DataAnnotations.Schema;

namespace DayOffMini.Domain.DTOs
{
    public class LeaveRequestDto
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string? EmployeeName { get; set; }

        public int LeaveTypeId { get; set; }
        public string? LeaveTypeName { get; set; }

        public int LeaveRequestStatusId { get; set; }
        public string? LeaveRequestStatusName { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal DurationInDays { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string? Reason { get; set; }
    }
}
