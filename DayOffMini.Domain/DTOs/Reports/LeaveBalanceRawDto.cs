namespace DayOffMini.Domain.DTOs.Reports
{
    public class LeaveBalanceRawDto
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = null!;
        public int LeaveTypeId { get; set; }
        public string LeaveTypeName { get; set; } = null!;
        public decimal FixedDaysOffBalance { get; set; }
        public decimal DaysTaken { get; set; }
    }
}
