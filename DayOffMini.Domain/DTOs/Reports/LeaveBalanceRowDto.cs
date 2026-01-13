namespace DayOffMini.Domain.DTOs.Reports
{
    public class LeaveBalanceRowDto
    {
        public int LeaveTypeId { get; set; }
        public string LeaveTypeName { get; set; } = null!;
        public decimal FixedDaysOffBalance { get; set; }
        public decimal DaysTaken { get; set; }
        public decimal DaysOffRemaining { get; set; }
    }

}
