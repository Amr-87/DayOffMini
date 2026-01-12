namespace DayOffMini.Domain.Interfaces.IRepositories
{
    public interface ILeaveRequestRepository
    {
        Task<decimal> GetTotalDaysOffTaken(int employeeId, int leaveTypeId);
    }
}
