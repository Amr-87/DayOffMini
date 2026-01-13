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
    }
}
