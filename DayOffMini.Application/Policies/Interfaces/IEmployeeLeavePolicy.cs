using DayOffMini.Domain.DTOs;

namespace DayOffMini.Application.Policies.Interfaces
{
    public interface IEmployeeLeavePolicy
    {
        IEnumerable<LeaveBalanceDto> CreateInitialLeaveBalances(int employeeId);
    }

}
