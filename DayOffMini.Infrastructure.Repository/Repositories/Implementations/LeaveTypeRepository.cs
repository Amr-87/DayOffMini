using DayOffMini.Domain.Interfaces.IRepositories;
using DayOffMini.Domain.Models;
using DayOffMini.Infrastructure.DbContext;
using DayOffMini.Infrastructure.Repository.Repositories.Generic;

namespace DayOffMini.Infrastructure.Repository.Repositories.Implementations
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        private readonly AppDbContext _dbContext;

        public LeaveTypeRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task UpdateAsync(LeaveType leaveType)
        {
            var existingLeaveType = await _dbContext.LeaveTypes.FindAsync(leaveType.Id);
            if (existingLeaveType == null)
                throw new KeyNotFoundException();

            existingLeaveType.Name = leaveType.Name;
            _dbContext.LeaveTypes.Update(existingLeaveType);
        }
    }
}
