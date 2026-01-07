using DayOffMini.Domain.DTOs;

namespace DayOffMini.Domain.Interfaces.IServices
{
    public interface ILeaveBalanceService
    {
        Task CreateAsync(LeaveBalanceDto dto);
        Task UpdateAsync(LeaveBalanceDto dto);
        Task<LeaveBalanceDto?> GetByIdAsync(int employeeId);
        Task<ICollection<LeaveBalanceDto>> GetAllAsync();
        Task DeleteAsync(int leaveBalanceId);
    }
}
