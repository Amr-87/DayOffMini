using DayOffMini.Controllers.DTOs;

namespace DayOffMini.Services.Interfaces
{
    public interface ILeaveRequestService
    {
        Task CreateAsync(LeaveRequestDto leaveRequest);
        Task UpdateAsync(LeaveRequestDto leaveRequest);
        Task<LeaveRequestDto?> GetByIdAsync(int leaveRequestId);
        Task<ICollection<LeaveRequestDto>> GetAllAsync();
        Task DeleteAsync(int leaveRequestId);

        Task SaveChangesAsync();
    }
}
