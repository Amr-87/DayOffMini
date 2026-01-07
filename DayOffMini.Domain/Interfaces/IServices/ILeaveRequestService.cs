using DayOffMini.Domain.DTOs;

namespace DayOffMini.Domain.Interfaces.IServices
{
    public interface ILeaveRequestService
    {
        Task CreateAsync(CreateLeaveRequestDto dto);
        Task UpdateAsync(LeaveRequestDto dto);
        Task<LeaveRequestDto?> GetByIdAsync(int leaveRequestId);
        Task<ICollection<LeaveRequestDto>> GetAllAsync();
        Task DeleteAsync(int leaveRequestId);
    }
}
