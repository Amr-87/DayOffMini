using DayOffMini.Application.Policies.Constants;
using DayOffMini.Application.Policies.Interfaces;
using DayOffMini.Domain.DTOs;

namespace DayOffMini.Application.Policies.Implementations
{
    public class DefaultEmployeeLeavePolicy : IEmployeeLeavePolicy
    {
        public IEnumerable<LeaveBalanceDto> CreateInitialLeaveBalances(int employeeId)
        {
            return new List<LeaveBalanceDto>
        {
            new LeaveBalanceDto
            {
                EmployeeId = employeeId,
                LeaveTypeId = LeaveTypeIds.Casual,
                TotalDaysRemaining = LeaveDefaults.CasualDays
            },
            new LeaveBalanceDto
            {
                EmployeeId = employeeId,
                LeaveTypeId = LeaveTypeIds.Scheduled,
                TotalDaysRemaining = LeaveDefaults.ScheduledDays
            }
        };
        }
    }

}
