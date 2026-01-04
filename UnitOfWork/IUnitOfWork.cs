using DayOffMini.Data.Models;
using DayOffMini.Repositories.Generic;
using DayOffMini.Repositories.Interfaces;

namespace DayOffMini.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();

        IEmployeeRepository Employees { get; }
        IGenericRepository<LeaveBalance> LeaveBalances { get; }
        IGenericRepository<LeaveRequest> LeaveRequests { get; }
        IGenericRepository<LeaveRequestStatus> LeaveRequestStatuses { get; }
        IGenericRepository<LeaveType> LeaveTypes { get; }

    }
}
