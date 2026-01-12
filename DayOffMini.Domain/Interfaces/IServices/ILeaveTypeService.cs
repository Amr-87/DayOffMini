using DayOffMini.Domain.DTOs;
using DayOffMini.Domain.DTOs.UpdateRequests;

namespace DayOffMini.Domain.Interfaces.IServices
{
    public interface ILeaveTypeService
    {
        Task CreateAsync(LeaveTypeDto leaveTypeDto);
        Task UpdateAsync(int id, UpdateLeaveTypeDto leaveTypeDto);
        Task<LeaveTypeDto?> GetByIdAsync(int leaveTypeId);
        Task<ICollection<LeaveTypeDto>> GetAllAsync();
    }
}
