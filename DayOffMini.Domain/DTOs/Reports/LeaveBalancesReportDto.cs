namespace DayOffMini.Domain.DTOs.Reports
{
    public class LeaveBalancesReportDto
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = null!;

        public decimal TotalDaysOffRemaining { get; set; }
        public decimal TotalDaysOffBalance { get; set; }

        public ICollection<LeaveBalanceRowDto> LeaveBalances { get; set; } = new List<LeaveBalanceRowDto>();
    }
}
