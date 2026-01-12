using DayOffMini.Domain.DTOs;
using DayOffMini.Domain.DTOs.UpdateRequests;
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
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateLeaveTypeDto dto)
        {
            await _leaveTypeService.UpdateAsync(id, dto);
            return NoContent();
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
            return Ok(dtos);
        }
    }
}
