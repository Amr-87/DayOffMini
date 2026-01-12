using DayOffMini.Domain.DTOs;
using DayOffMini.Domain.DTOs.CreateRequests;
using DayOffMini.Domain.DTOs.UpdateRequests;

namespace DayOffMini.Domain.Interfaces.IServices
{
    public interface IEmployeeService
    {
        Task CreateAsync(CreateEmployeeDto employeeDto);
        Task UpdateAsync(int id, UpdateEmployeeDto updateDto);
        Task<EmployeeDto?> GetByIdAsync(int employeeId);
        Task<ICollection<EmployeeDto>> GetAllAsync();
        Task DeleteAsync(int employeeId);
    }
}
