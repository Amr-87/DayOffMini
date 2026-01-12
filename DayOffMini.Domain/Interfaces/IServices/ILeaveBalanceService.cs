using DayOffMini.Domain.DTOs;
using DayOffMini.Domain.DTOs.Reports;
using DayOffMini.Domain.DTOs.UpdateRequests;

namespace DayOffMini.Domain.Interfaces.IServices
{
    public interface ILeaveBalanceService
    {
        Task UpdateEmployeeLeaveBalanceAsync(int employeeId, int leaveBalanceId, UpdateLeaveBalanceDto dto);
        Task<ICollection<LeaveBalanceDto>> GetEmployeeLeaveBalancesAsync(int employeeId);
        Task<ICollection<LeaveBalancesReportDto>> GetLeaveBalancesReportAsync();
    }
}
