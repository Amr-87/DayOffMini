using DayOffMini.Domain.DTOs;

namespace DayOffMini.Domain.Interfaces.IServices
{
    public interface ILeaveRequestStatusService
    {
        Task CreateAsync(LeaveRequestStatusDto dto);
        Task UpdateAsync(LeaveRequestStatusDto dto);
        Task<LeaveRequestStatusDto?> GetByIdAsync(int id);
        Task<ICollection<LeaveRequestStatusDto>> GetAllAsync();
        Task DeleteAsync(int leaveRequestStatusId);
    }
}
