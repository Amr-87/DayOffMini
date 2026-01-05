using DayOffMini.Controllers.DTOs;
using DayOffMini.Controllers.Mapping.Interfaces;
using DayOffMini.Data.Models;

namespace DayOffMini.Controllers.Mapping.Implementations
{
    public class EmployeeMapper : IEmployeeMapper
    {
        public EmployeeDto ToDto(Employee employee)
        {
            return new EmployeeDto
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Password = employee.Password
            };
        }

        public Employee ToEntity(EmployeeDto dto)
        {
            return new Employee
            {
                Id = dto.Id,
                Name = dto.Name,
                Email = dto.Email,
                Password = dto.Password
            };
        }
    }
}
