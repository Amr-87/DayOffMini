using DayOffMini.Domain.DTOs.Reports;

namespace DayOffMini.Domain.Interfaces.IRepositories
{
    public interface ILeaveBalanceRepository
    {
        Task<decimal> GetFixedDaysOffBalance(int employeeId, int leaveTypeId);

        Task<ICollection<LeaveBalanceRawDto>> GetLeaveBalancesRawDataAsync();
    }
}
