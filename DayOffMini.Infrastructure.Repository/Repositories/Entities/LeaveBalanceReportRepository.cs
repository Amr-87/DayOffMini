using DayOffMini.Domain.DTOs.Reports;
using DayOffMini.Domain.Interfaces.IRepositories;
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
            return await _context.LeaveBalances
                .AsNoTracking()
                .GroupBy(lb => new
                {
                    lb.EmployeeId,
                    lb.Employee.Name
                })
                .Select(g => new LeaveBalancesReportDto
                {
                    EmployeeId = g.Key.EmployeeId,
                    EmployeeName = g.Key.Name!,

                    //TotalDaysOffRemaining = g.Sum(x => x.DaysOffRemaining),
                    TotalDaysOffBalance = g.Sum(x => x.LeaveType.DaysOffBalance ?? 0),

                    LeaveBalances = g.Select(x => new LeaveBalanceRowDto
                    {
                        LeaveTypeId = x.LeaveTypeId,
                        LeaveTypeName = x.LeaveType.Name,
                        //DaysOffRemaining = x.DaysOffRemaining,
                        DaysOffBalance = x.LeaveType.DaysOffBalance ?? 0
                    }).ToList()
                })
                .ToListAsync();
        }
    }

}
