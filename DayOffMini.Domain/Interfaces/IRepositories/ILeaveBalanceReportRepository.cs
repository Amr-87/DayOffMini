using DayOffMini.Domain.DTOs.Reports;

namespace DayOffMini.Domain.Interfaces.IRepositories
{
    public interface ILeaveBalanceReportRepository
    {
        Task<ICollection<LeaveBalancesReportDto>> GetLeaveBalancesReportAsync();
    }
}
