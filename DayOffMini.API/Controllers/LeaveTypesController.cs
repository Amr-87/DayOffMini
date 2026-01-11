using DayOffMini.Domain.DTOs;
using DayOffMini.Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace DayOffMini.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTypesController : ControllerBase
    {
        private readonly ILeaveTypeService _leaveTypeService;

        public LeaveTypesController(ILeaveTypeService leaveTypeService)
        {
            _leaveTypeService = leaveTypeService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LeaveTypeDto dto)
        {
            await _leaveTypeService.CreateAsync(dto);
            return Ok("leave type created successfully");
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] LeaveTypeDto dto)
        {
            var existingLeaveType = await _leaveTypeService.GetByIdAsync(dto.Id);
            if (existingLeaveType == null)
            {
                return BadRequest("leave type not found");
            }
            await _leaveTypeService.UpdateAsync(dto);
            return Ok("leave type updated successfully");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var dto = await _leaveTypeService.GetByIdAsync(id);
            if (dto == null)
            {
                return NotFound("leave type not found");
            }
            return Ok(dto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var dtos = await _leaveTypeService.GetAllAsync();
            if (!dtos.Any())
                return NoContent();

            return Ok(dtos);
        }
    }
}
