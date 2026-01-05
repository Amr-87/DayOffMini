using DayOffMini.Domain.Models;

namespace DayOffMini.Domain.Interfaces.Repositories
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task UpdateAsync(Employee employee);
    }
}
