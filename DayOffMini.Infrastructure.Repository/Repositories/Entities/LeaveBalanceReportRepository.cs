using DayOffMini.Domain.DTOs.Reports;
using DayOffMini.Domain.Interfaces.IRepositories;
using DayOffMini.Domain.Models;
using DayOffMini.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace DayOffMini.Infrastructure.Repository.Repositories.Entities
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
            ICollection<Employee> employees = await _context.Employees.AsNoTracking().ToListAsync();
            ICollection<LeaveType> leaveTypes = await _context.LeaveTypes.AsNoTracking().ToListAsync();
            ICollection<LeaveBalance> leaveBalances = await _context.LeaveBalances
                .AsNoTracking()
                .Include(lb => lb.Employee)
                .Include(lb => lb.LeaveType)
                .ToListAsync();

            var leaveRequestsAgg = await _context.LeaveRequests
                .AsNoTracking()
                .GroupBy(lr => new { lr.EmployeeId, lr.LeaveTypeId })
                .Select(g => new
                {
                    g.Key.EmployeeId,
                    g.Key.LeaveTypeId,
                    TotalDaysTaken = g.Sum(x => x.DurationInDays)
                })
                .ToListAsync();

            ICollection<LeaveBalancesReportDto> report = employees.Select(emp => new LeaveBalancesReportDto
            {
                EmployeeId = emp.Id,
                EmployeeName = emp.Name!,
                LeaveBalances = leaveTypes.Select(lt =>
                {
                    LeaveBalance? balance = leaveBalances.FirstOrDefault(lb =>
                        lb.EmployeeId == emp.Id && lb.LeaveTypeId == lt.Id);

                    decimal daysTaken = leaveRequestsAgg
                        .FirstOrDefault(lr => lr.EmployeeId == emp.Id && lr.LeaveTypeId == lt.Id)
                        ?.TotalDaysTaken ?? 0;

                    decimal fixedBalance = balance?.FixedDaysOffBalance ?? 0;

                    return new LeaveBalanceRowDto
                    {
                        LeaveTypeId = lt.Id,
                        LeaveTypeName = lt.Name,
                        FixedDaysOffBalance = fixedBalance,
                        DaysTaken = daysTaken,
                        DaysOffRemaining = fixedBalance - daysTaken
                    };
                }).ToList()
            }).ToList();

            foreach (var emp in report)
            {
                emp.TotalDaysOffBalance = emp.LeaveBalances.Sum(x => x.FixedDaysOffBalance);
                emp.TotalDaysOffRemaining = emp.LeaveBalances.Sum(x => x.DaysOffRemaining);
            }

            return report;
        }
    }

}
