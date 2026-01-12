namespace DayOffMini.Domain.DTOs.Reports
{
    public class LeaveBalanceRowDto
    {
        public int LeaveTypeId { get; set; }
        public string LeaveTypeName { get; set; } = null!;
        public decimal DaysOffRemaining { get; set; }
        public decimal DaysOffBalance { get; set; }
    }

}
