using DayOffMini.Domain.DTOs;

namespace DayOffMini.Domain.Interfaces.IServices
{
    public interface ILeaveRequestStatusService
    {
        Task<LeaveRequestStatusDto?> GetByIdAsync(int id);
        Task<ICollection<LeaveRequestStatusDto>> GetAllAsync();
    }
}
