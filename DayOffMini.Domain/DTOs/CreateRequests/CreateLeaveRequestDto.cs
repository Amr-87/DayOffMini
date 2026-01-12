namespace DayOffMini.Domain.DTOs.CreateRequests
{
    public class CreateLeaveRequestDto
    {
        public int LeaveTypeId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Reason { get; set; }

    }
}
