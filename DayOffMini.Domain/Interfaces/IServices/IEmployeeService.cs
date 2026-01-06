using DayOffMini.Domain.DTOs;

namespace DayOffMini.Domain.Interfaces.IServices
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
