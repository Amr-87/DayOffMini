using DayOffMini.Application.DTOs;

namespace DayOffMini.Application.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task CreateAsync(EmployeeDto employeeDto);
        Task UpdateAsync(EmployeeDto employeeDto);
        Task<EmployeeDto?> GetByIdAsync(int employeeId);
        Task<ICollection<EmployeeDto>> GetAllAsync();
        Task DeleteAsync(int employeeId);
    }
}
