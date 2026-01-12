namespace DayOffMini.Domain.DTOs.UpdateRequests
{
    public class UpdateLeaveRequestDto
    {
        public int LeaveTypeId { get; set; }

        public int LeaveRequestStatusId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Reason { get; set; }
    }
}
