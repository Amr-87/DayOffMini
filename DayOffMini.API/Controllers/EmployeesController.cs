using DayOffMini.Domain.DTOs;
using DayOffMini.Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace DayOffMini.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeDto dto)
        {
            await _employeeService.CreateAsync(dto);
            return Ok("employee created successfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee([FromBody] EmployeeDto dto)
        {
            await _employeeService.UpdateAsync(dto);
            return Ok("employee updated successfully");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employeeDto = await _employeeService.GetByIdAsync(id);
            return Ok(employeeDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employeesDto = await _employeeService.GetAllAsync();
            return Ok(employeesDto);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _employeeService.DeleteAsync(id);
            return Ok("employee deleted successfully");
        }
    }
}
