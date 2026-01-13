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
            ICollection<LeaveBalanceRawDto> query = await _db.Employees
                .AsNoTracking()
                .SelectMany(emp => _db.LeaveTypes, (emp, lt) => new { emp, lt })
                .GroupJoin(
                    _db.LeaveBalances,
                    x => new { EmployeeId = x.emp.Id, LeaveTypeId = x.lt.Id },
                    lb => new { lb.EmployeeId, lb.LeaveTypeId },
                    (x, balances) => new { x.emp, x.lt, balances }
                )
                .SelectMany(
                    x => x.balances.DefaultIfEmpty(),
                    (x, balance) => new { x.emp, x.lt, balance }
                )
                .GroupJoin(
                    _db.LeaveRequests
                        .GroupBy(lr => new { lr.EmployeeId, lr.LeaveTypeId })
                        .Select(g => new
                        {
                            g.Key.EmployeeId,
                            g.Key.LeaveTypeId,
                            TotalDaysTaken = g.Sum(x => x.DurationInDays)
                        }),
                    x => new { EmployeeId = x.emp.Id, LeaveTypeId = x.lt.Id },
                    lr => new { lr.EmployeeId, lr.LeaveTypeId },
                    (x, requests) => new { x.emp, x.lt, x.balance, requests }
                )
                .SelectMany(
                    x => x.requests.DefaultIfEmpty(),
                    (x, request) => new LeaveBalanceRawDto
                    {
                        EmployeeId = x.emp.Id,
                        EmployeeName = x.emp.Name!,
                        LeaveTypeId = x.lt.Id,
                        LeaveTypeName = x.lt.Name,
                        FixedDaysOffBalance = (decimal?)(x.balance != null ? x.balance.FixedDaysOffBalance : (decimal?)null) ?? 0,
                        DaysTaken = (decimal?)(request != null ? request.TotalDaysTaken : (decimal?)null) ?? 0
                    }
                )
                .ToListAsync();

            return query;
        }
    }
}
