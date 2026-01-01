using DayOffMini.Controllers.DTOs;
using DayOffMini.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DayOffMini.Controllers
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
            catch (Exception ex)
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
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            try
            {
                var employeeDto = await _employeeService.GetByIdAsync(id);
                return Ok(employeeDto);
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
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
