using DayOffMini.Domain.DTOs;

namespace DayOffMini.Domain.Interfaces.IServices
{
    public interface IEmployeeService
    {
        Task CreateAsync(CreateEmployeeDto employeeDto);
        Task UpdateAsync(int id, UpdateEmployeeDto updateDto);
        Task<EmployeeDto?> GetByIdAsync(int employeeId);
        Task<ICollection<EmployeeDto>> GetAllAsync();
        Task DeleteAsync(EmployeeDto employeeDto);
    }
}
