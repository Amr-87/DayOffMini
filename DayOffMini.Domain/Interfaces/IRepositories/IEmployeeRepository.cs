using DayOffMini.Domain.Models;

namespace DayOffMini.Domain.Interfaces.IRepositories
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task UpdateAsync(Employee employee);
    }
}
