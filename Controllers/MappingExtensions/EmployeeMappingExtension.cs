using DayOffMini.Controllers.DTOs;
using DayOffMini.Data.Models;

namespace DayOffMini.Controllers.MappingExtensions
{
    public static class EmployeeMappingExtension
    {
        public static EmployeeDto ToDto(this Employee? employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException();
            }
            return new EmployeeDto
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Password = employee.Password

            };
        }

        public static Employee ToEntity(this EmployeeDto dto)
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
