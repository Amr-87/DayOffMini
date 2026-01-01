using DayOffMini.Controllers.DTOs;

namespace DayOffMini.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task CreateAsync(EmployeeDto employee);
        Task UpdateAsync(EmployeeDto employee);
        Task<EmployeeDto?> GetByIdAsync(int employeeId);
        Task<ICollection<EmployeeDto>> GetAllAsync();
        Task DeleteAsync(int employeeId);

        Task SaveChangesAsync();
    }
}
