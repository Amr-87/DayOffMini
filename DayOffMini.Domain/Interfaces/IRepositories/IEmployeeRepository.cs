using DayOffMini.Domain.Models;

namespace DayOffMini.Domain.Interfaces.IRepositories
{
    public interface IEmployeeRepository
    {
        Task<Employee?> GetEmployeeByEmailAsync(string email);
    }
}
