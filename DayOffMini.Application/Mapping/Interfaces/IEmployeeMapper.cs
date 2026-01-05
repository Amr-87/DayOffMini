using DayOffMini.Application.DTOs;
using DayOffMini.Domain.Models;

namespace DayOffMini.Application.Mapping.Interfaces
{
    public interface IEmployeeMapper
    {
        EmployeeDto ToDto(Employee employee);
        Employee ToEntity(EmployeeDto dto);
    }
}
