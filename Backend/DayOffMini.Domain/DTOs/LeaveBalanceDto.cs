using System.ComponentModel.DataAnnotations.Schema;

namespace DayOffMini.Domain.DTOs
{
    public class LeaveBalanceDto
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public int LeaveTypeId { get; set; }
        public string? LeaveTypeName { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal FixedDaysOffBalance { get; set; }
    }
}
