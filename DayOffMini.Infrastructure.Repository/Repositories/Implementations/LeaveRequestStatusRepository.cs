using DayOffMini.Domain.Interfaces.IRepositories;
using DayOffMini.Domain.Models;
using DayOffMini.Infrastructure.DbContext;
using DayOffMini.Infrastructure.Repository.Repositories.Generic;

namespace DayOffMini.Infrastructure.Repository.Repositories.Implementations
{
    public class LeaveRequestStatusRepository : GenericRepository<LeaveRequestStatus>, ILeaveRequestStatusRepository
    {
        private readonly AppDbContext _dbContext;

        public LeaveRequestStatusRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task UpdateAsync(LeaveRequestStatus leaveRequestStatus)
        {
            var existingLeaveRequestStatus = await _dbContext.LeaveRequestStatuses.FindAsync(leaveRequestStatus.Id);
            if (existingLeaveRequestStatus == null)
                throw new KeyNotFoundException();

            existingLeaveRequestStatus.Name = leaveRequestStatus.Name;
            _dbContext.LeaveRequestStatuses.Update(existingLeaveRequestStatus);
        }
    }
}
