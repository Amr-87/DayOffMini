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
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeDto dto)
        {
            try
            {
                await _employeeService.CreateAsync(dto);
                return Ok("employee created successfully");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee([FromBody] EmployeeDto dto)
        {
            try
            {
                await _employeeService.UpdateAsync(dto);
                return Ok("employee updated successfully");
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employeeDto = await _employeeService.GetByIdAsync(id);
            if (employeeDto == null)
                return NotFound();
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
            try
            {
                await _employeeService.DeleteAsync(id);
                return Ok("employee deleted successfully");
            }
            catch (KeyNotFoundException)
            {
                return BadRequest();
            }

        }
    }
}
