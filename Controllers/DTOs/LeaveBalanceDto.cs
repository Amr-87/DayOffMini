namespace DayOffMini.Controllers.DTOs
{
    public class LeaveBalanceDto
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }
        public int LeaveTypeId { get; set; }
        public int TotalDaysRemaining { get; set; }

    }
}
