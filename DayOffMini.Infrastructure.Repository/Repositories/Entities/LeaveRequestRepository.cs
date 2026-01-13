using DayOffMini.Domain.Interfaces.IRepositories;
using DayOffMini.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace DayOffMini.Infrastructure.Repository.Repositories.Entities
{
    public class LeaveRequestRepository : ILeaveRequestRepository
    {
        private readonly AppDbContext _db;

        public LeaveRequestRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Task<decimal> GetTotalDaysOffTaken(int employeeId, int leaveTypeId)
        {
            return await _db.LeaveRequests.AsNoTracking()
                 .Where(lr => lr.EmployeeId == employeeId && lr.LeaveTypeId == leaveTypeId)
                 .SumAsync(lr => (decimal?)lr.DurationInDays) ?? 0;
        }
    }
}
