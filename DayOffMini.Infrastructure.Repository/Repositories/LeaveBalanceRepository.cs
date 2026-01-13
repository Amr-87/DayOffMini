using DayOffMini.Domain.DTOs.Reports;
using DayOffMini.Domain.Interfaces.IRepositories;
using DayOffMini.Domain.Models;
using DayOffMini.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace DayOffMini.Infrastructure.Repository.Repositories
{
    public class LeaveBalanceRepository : ILeaveBalanceRepository
    {
        private readonly AppDbContext _db;

        public LeaveBalanceRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Task<decimal> GetFixedDaysOffBalance(int employeeId, int leaveTypeId)
        {
            LeaveBalance? leaveBalance = await _db.LeaveBalances
                .FirstOrDefaultAsync(b => b.EmployeeId == employeeId && b.LeaveTypeId == leaveTypeId);

            return leaveBalance?.FixedDaysOffBalance ?? 0;
        }

        public async Task<ICollection<LeaveBalanceRawDto>> GetLeaveBalancesRawDataAsync()
        {
            ICollection<LeaveBalanceRawDto> query = await (
                from employee in _db.Employees
                from leaveType in _db.LeaveTypes
                join leaveBalance in _db.LeaveBalances
                    on new { EmployeeId = employee.Id, LeaveTypeId = leaveType.Id }
                    equals new { leaveBalance.EmployeeId, leaveBalance.LeaveTypeId }
                    into leaveBalanceGroup
                from leaveBalance in leaveBalanceGroup.DefaultIfEmpty()
                select new
                {
                    EmployeeId = employee.Id,
                    EmployeeName = employee.Name!,
                    LeaveTypeId = leaveType.Id,
                    LeaveTypeName = leaveType.Name,
                    FixedDaysOffBalance = leaveBalance == null ? 0 : leaveBalance.FixedDaysOffBalance,
                    // Get days taken in a separate subquery
                    DaysTaken = (decimal?)_db.LeaveRequests
                        .Where(lr => lr.EmployeeId == employee.Id && lr.LeaveTypeId == leaveType.Id)
                        .Sum(lr => (decimal?)lr.DurationInDays) ?? 0
                }
            )
            .AsNoTracking()
            .Select(x => new LeaveBalanceRawDto
            {
                EmployeeId = x.EmployeeId,
                EmployeeName = x.EmployeeName,
                LeaveTypeId = x.LeaveTypeId,
                LeaveTypeName = x.LeaveTypeName,
                FixedDaysOffBalance = x.FixedDaysOffBalance,
                DaysTaken = x.DaysTaken
            })
            .ToListAsync();

            return query;
        }
    }
}
