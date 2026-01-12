using DayOffMini.Domain.DTOs;
using DayOffMini.Domain.DTOs.CreateRequests;
using DayOffMini.Domain.DTOs.UpdateRequests;

namespace DayOffMini.Domain.Interfaces.IServices
{
    public interface ILeaveRequestService
    {
        Task CreateAsync(CreateLeaveRequestDto dto);
        Task<LeaveRequestDto?> GetByIdAsync(int leaveRequestId);
        Task DeleteAsync(int employeeId, int leaveRequestId);
        Task<ICollection<LeaveRequestDto>> GetEmployeeLeaveRequestsAsync(int employeeId);
        Task UpdateEmployeeLeaveRequestAsync(int employeeId, int leaveRequestId, UpdateLeaveRequestDto dto);
    }
}
