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
            decimal totalDaysOffTaken = await _db.LeaveRequests.Where(lr => lr.EmployeeId == employeeId && lr.LeaveTypeId == leaveTypeId)
                 .SumAsync(lr => lr.DurationInDays);

            return totalDaysOffTaken;
        }
    }
}
