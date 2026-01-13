using DayOffMini.Domain.DTOs.Reports;
using DayOffMini.Domain.Interfaces.IRepositories;
using DayOffMini.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace DayOffMini.Infrastructure.Repository.Repositories
{
    public class LeaveBalanceReportRepository : ILeaveBalanceReportRepository
    {
        private readonly AppDbContext _context;

        public LeaveBalanceReportRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ICollection<LeaveBalancesReportDto>> GetLeaveBalancesReportAsync()
        {
            // Single query with all joins and aggregations
            var query = await _context.Employees
                .AsNoTracking()
                .SelectMany(emp => _context.LeaveTypes, (emp, lt) => new { emp, lt })
                .GroupJoin(
                    _context.LeaveBalances,
                    x => new { EmployeeId = x.emp.Id, LeaveTypeId = x.lt.Id },
                    lb => new { lb.EmployeeId, lb.LeaveTypeId },
                    (x, balances) => new { x.emp, x.lt, balances }
                )
                .SelectMany(
                    x => x.balances.DefaultIfEmpty(),
                    (x, balance) => new { x.emp, x.lt, balance }
                )
                .GroupJoin(
                    _context.LeaveRequests
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
                    (x, request) => new
                    {
                        EmployeeId = x.emp.Id,
                        EmployeeName = x.emp.Name,
                        LeaveTypeId = x.lt.Id,
                        LeaveTypeName = x.lt.Name,
                        // Handle nulls properly
                        FixedDaysOffBalance = (decimal?)(x.balance != null ? x.balance.FixedDaysOffBalance : (decimal?)null) ?? 0,
                        DaysTaken = (decimal?)(request != null ? request.TotalDaysTaken : (decimal?)null) ?? 0
                    }
                )
                .ToListAsync();

            // Group in memory (minimal processing)
            var report = query
                .GroupBy(x => new { x.EmployeeId, x.EmployeeName })
                .Select(empGroup => new LeaveBalancesReportDto
                {
                    EmployeeId = empGroup.Key.EmployeeId,
                    EmployeeName = empGroup.Key.EmployeeName!,
                    LeaveBalances = empGroup.Select(x => new LeaveBalanceRowDto
                    {
                        LeaveTypeId = x.LeaveTypeId,
                        LeaveTypeName = x.LeaveTypeName,
                        FixedDaysOffBalance = x.FixedDaysOffBalance,
                        DaysTaken = x.DaysTaken,
                        DaysOffRemaining = x.FixedDaysOffBalance - x.DaysTaken
                    }).ToList(),
                    TotalDaysOffBalance = empGroup.Sum(x => x.FixedDaysOffBalance),
                    TotalDaysOffRemaining = empGroup.Sum(x => x.FixedDaysOffBalance - x.DaysTaken)
                })
                .ToList();

            return report;
        }

        //public async Task<ICollection<LeaveBalancesReportDto>> GetLeaveBalancesReportAsync()
        //{
        //    // Pre-aggregate leave requests
        //    var leaveRequestsAgg = await _context.LeaveRequests
        //        .AsNoTracking()
        //        .GroupBy(lr => new { lr.EmployeeId, lr.LeaveTypeId })
        //        .Select(g => new
        //        {
        //            g.Key.EmployeeId,
        //            g.Key.LeaveTypeId,
        //            TotalDaysTaken = g.Sum(x => x.DurationInDays)
        //        })
        //        .ToDictionaryAsync(x => new { x.EmployeeId, x.LeaveTypeId }, x => x.TotalDaysTaken);

        //    // Main query
        //    var query = await (
        //        from emp in _context.Employees
        //        from lt in _context.LeaveTypes
        //        join lb in _context.LeaveBalances
        //            on new { EmployeeId = emp.Id, LeaveTypeId = lt.Id }
        //            equals new { lb.EmployeeId, lb.LeaveTypeId }
        //            into leaveBalances
        //        from lb in leaveBalances.DefaultIfEmpty()
        //        select new
        //        {
        //            EmployeeId = emp.Id,
        //            EmployeeName = emp.Name,
        //            LeaveTypeId = lt.Id,
        //            LeaveTypeName = lt.Name,
        //            FixedDaysOffBalance = lb != null ? lb.FixedDaysOffBalance : 0m
        //        }
        //    ).AsNoTracking().ToListAsync();

        //    // Build report in memory
        //    var report = query
        //        .GroupBy(x => new { x.EmployeeId, x.EmployeeName })
        //        .Select(empGroup => new LeaveBalancesReportDto
        //        {
        //            EmployeeId = empGroup.Key.EmployeeId,
        //            EmployeeName = empGroup.Key.EmployeeName,
        //            LeaveBalances = empGroup.Select(x =>
        //            {
        //                var key = new { EmployeeId = x.EmployeeId, LeaveTypeId = x.LeaveTypeId };
        //                decimal daysTaken = leaveRequestsAgg.TryGetValue(key, out var taken) ? taken : 0;

        //                return new LeaveBalanceRowDto
        //                {
        //                    LeaveTypeId = x.LeaveTypeId,
        //                    LeaveTypeName = x.LeaveTypeName,
        //                    FixedDaysOffBalance = x.FixedDaysOffBalance,
        //                    DaysTaken = daysTaken,
        //                    DaysOffRemaining = x.FixedDaysOffBalance - daysTaken
        //                };
        //            }).ToList(),
        //            TotalDaysOffBalance = empGroup.Sum(x => x.FixedDaysOffBalance),
        //            TotalDaysOffRemaining = empGroup.Sum(x =>
        //            {
        //                var key = new { EmployeeId = x.EmployeeId, LeaveTypeId = x.LeaveTypeId };
        //                decimal daysTaken = leaveRequestsAgg.TryGetValue(key, out var taken) ? taken : 0;
        //                return x.FixedDaysOffBalance - daysTaken;
        //            })
        //        })
        //        .ToList();

        //    return report;
        //}

        //public async Task<ICollection<LeaveBalancesReportDto>> GetLeaveBalancesReportAsync()
        //{
        //    var report = await _context.Employees
        //        .AsNoTracking()
        //        .Select(emp => new LeaveBalancesReportDto
        //        {
        //            EmployeeId = emp.Id,
        //            EmployeeName = emp.Name!,
        //            LeaveBalances = _context.LeaveTypes
        //                .Select(lt => new LeaveBalanceRowDto
        //                {
        //                    LeaveTypeId = lt.Id,
        //                    LeaveTypeName = lt.Name,
        //                    FixedDaysOffBalance = _context.LeaveBalances
        //                        .Where(lb => lb.EmployeeId == emp.Id && lb.LeaveTypeId == lt.Id)
        //                        .Select(lb => lb.FixedDaysOffBalance)
        //                        .FirstOrDefault(),
        //                    DaysTaken = _context.LeaveRequests
        //                        .Where(lr => lr.EmployeeId == emp.Id && lr.LeaveTypeId == lt.Id)
        //                        .Sum(lr => (decimal?)lr.DurationInDays) ?? 0,
        //                    DaysOffRemaining = _context.LeaveBalances
        //                        .Where(lb => lb.EmployeeId == emp.Id && lb.LeaveTypeId == lt.Id)
        //                        .Select(lb => lb.FixedDaysOffBalance)
        //                        .FirstOrDefault() -
        //                        (_context.LeaveRequests
        //                        .Where(lr => lr.EmployeeId == emp.Id && lr.LeaveTypeId == lt.Id)
        //                        .Sum(lr => (decimal?)lr.DurationInDays) ?? 0)
        //                })
        //                .ToList(),
        //            TotalDaysOffBalance = _context.LeaveBalances
        //                .Where(lb => lb.EmployeeId == emp.Id)
        //                .Sum(lb => (decimal?)lb.FixedDaysOffBalance) ?? 0,
        //            TotalDaysOffRemaining = _context.LeaveBalances
        //                .Where(lb => lb.EmployeeId == emp.Id)
        //                .Select(lb => new
        //                {
        //                    lb.LeaveTypeId,
        //                    lb.FixedDaysOffBalance
        //                })
        //                .GroupJoin(
        //                    _context.LeaveRequests.Where(lr => lr.EmployeeId == emp.Id),
        //                    lb => lb.LeaveTypeId,
        //                    lr => lr.LeaveTypeId,
        //                    (lb, lrs) => lb.FixedDaysOffBalance - lrs.Sum(lr => (decimal?)lr.DurationInDays) ?? 0
        //                )
        //                .Sum(remaining => (decimal?)remaining) ?? 0
        //        })
        //        .ToListAsync();

        //    return report;
        //}
    }

}
