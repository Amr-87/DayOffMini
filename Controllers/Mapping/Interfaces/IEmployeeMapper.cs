using DayOffMini.Controllers.DTOs;
using DayOffMini.Data.Models;

namespace DayOffMini.Controllers.Mapping.Interfaces
{
    public interface IEmployeeMapper
    {
        EmployeeDto ToDto(Employee employee);
        Employee ToEntity(EmployeeDto dto);
    }
}
