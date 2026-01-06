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
            try
            {
                await _leaveTypeService.CreateAsync(dto);
                return Ok("leave type created successfully");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] LeaveTypeDto dto)
        {
            try
            {
                await _leaveTypeService.UpdateAsync(dto);
                return Ok("leave type updated successfully");
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
        public async Task<IActionResult> GetById(int id)
        {
            var dto = await _leaveTypeService.GetByIdAsync(id);
            if (dto == null)
                return NotFound();
            return Ok(dto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var dtos = await _leaveTypeService.GetAllAsync();
            return Ok(dtos);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _leaveTypeService.DeleteAsync(id);
                return Ok("leave type deleted successfully");
            }
            catch (KeyNotFoundException)
            {
                return BadRequest();
            }

        }
    }
}
