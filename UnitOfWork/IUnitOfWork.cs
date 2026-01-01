using DayOffMini.Data.Models;
using DayOffMini.Repositories.Generic;

namespace DayOffMini.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();

        IGenericRepository<Employee> Employees { get; }
        IGenericRepository<LeaveBalance> LeaveBalances { get; }
        IGenericRepository<LeaveRequest> LeaveRequests { get; }
        IGenericRepository<LeaveRequestStatus> LeaveRequestStatuses { get; }
        IGenericRepository<LeaveType> LeaveTypes { get; }

    }
}
