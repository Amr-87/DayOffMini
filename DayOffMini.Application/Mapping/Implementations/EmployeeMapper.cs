using DayOffMini.Application.DTOs;
using DayOffMini.Application.Mapping.Interfaces;
using DayOffMini.Domain.Models;

namespace DayOffMini.Application.Mapping.Implementations
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
