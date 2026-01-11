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
        public async Task<IActionResult> Create([FromBody] CreateEmployeeDto dto)
        {
            await _employeeService.CreateAsync(dto);
            return Ok("employee created successfully");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateEmployeeDto dto)
        {
            await _employeeService.UpdateAsync(id, dto);
            return NoContent(); // REST standard for PUT
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employeeDto = await _employeeService.GetByIdAsync(id);
            if (employeeDto == null)
            {
                return NotFound("employee not found");
            }
            return Ok(employeeDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var dtos = await _employeeService.GetAllAsync();
            if (!dtos.Any())
                return NoContent();

            return Ok(dtos);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var existingEmployee = await _employeeService.GetByIdAsync(id);
            if (existingEmployee == null)
            {
                return BadRequest("employee not found");
            }
            await _employeeService.DeleteAsync(existingEmployee);
            return Ok("employee deleted successfully");
        }
    }
}
