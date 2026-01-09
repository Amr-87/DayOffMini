using DayOffMini.Domain.DTOs;

namespace DayOffMini.Domain.Interfaces.IServices
{
    public interface ILeaveTypeService
    {
        Task CreateAsync(LeaveTypeDto leaveTypeDto);
        Task UpdateAsync(LeaveTypeDto leaveTypeDto);
        Task<LeaveTypeDto?> GetByIdAsync(int leaveTypeId);
        Task<ICollection<LeaveTypeDto>> GetAllAsync();
    }
}
