using DayOffMini.Domain.Models;

namespace DayOffMini.Domain.Interfaces.IRepositories
{
    public interface ILeaveRequestStatusRepository : IGenericRepository<LeaveRequestStatus>
    {
        Task UpdateAsync(LeaveRequestStatus leaveRequestStatus);
    }
}
