using DayOffMini.Data.DbContext;
using DayOffMini.Data.Models;
using DayOffMini.Repositories.Generic;
using DayOffMini.Repositories.Interfaces;

namespace DayOffMini.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        public IEmployeeRepository Employees { get; }
        public IGenericRepository<LeaveBalance> LeaveBalances { get; }
        public IGenericRepository<LeaveRequest> LeaveRequests { get; }
        public IGenericRepository<LeaveRequestStatus> LeaveRequestStatuses { get; }
        public IGenericRepository<LeaveType> LeaveTypes { get; }

        public UnitOfWork(AppDbContext dbContext,
            IEmployeeRepository employees,
            IGenericRepository<LeaveBalance> leaveBalances,
            IGenericRepository<LeaveRequest> leaveRequests,
            IGenericRepository<LeaveRequestStatus> leaveRequestStatuses,
            IGenericRepository<LeaveType> leaveTypes
            )
        {
            _dbContext = dbContext;
            Employees = employees;
            LeaveBalances = leaveBalances;
            LeaveRequests = leaveRequests;
            LeaveRequestStatuses = leaveRequestStatuses;
            LeaveTypes = leaveTypes;
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
