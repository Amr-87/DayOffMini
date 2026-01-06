using DayOffMini.Domain.Models;

namespace DayOffMini.Domain.Interfaces.IRepositories
{
    public interface ILeaveTypeRepository : IGenericRepository<LeaveType>
    {
        Task UpdateAsync(LeaveType leaveType);
    }
}
