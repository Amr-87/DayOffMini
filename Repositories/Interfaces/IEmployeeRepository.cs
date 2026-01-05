using DayOffMini.Data.Models;
using DayOffMini.Repositories.Generic;

namespace DayOffMini.Repositories.Interfaces
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task UpdateAsync(Employee employee);
    }
}
