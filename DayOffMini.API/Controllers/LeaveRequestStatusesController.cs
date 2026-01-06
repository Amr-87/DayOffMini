using DayOffMini.Domain.DTOs;
using DayOffMini.Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace DayOffMini.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestStatusesController : ControllerBase
    {
        private readonly ILeaveRequestStatusService _leaveRequestStatusService;

        public LeaveRequestStatusesController(ILeaveRequestStatusService leaveRequestStatusService)
        {
            _leaveRequestStatusService = leaveRequestStatusService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LeaveRequestStatusDto dto)
        {
            try
            {
                await _leaveRequestStatusService.CreateAsync(dto);
                return Ok("leave request status created successfully");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] LeaveRequestStatusDto dto)
        {
            try
            {
                await _leaveRequestStatusService.UpdateAsync(dto);
                return Ok("leave request status updated successfully");
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
            var dto = await _leaveRequestStatusService.GetByIdAsync(id);
            if (dto == null)
                return NotFound();
            return Ok(dto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var dtos = await _leaveRequestStatusService.GetAllAsync();
            return Ok(dtos);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _leaveRequestStatusService.DeleteAsync(id);
                return Ok("leave request status deleted successfully");
            }
            catch (KeyNotFoundException)
            {
                return BadRequest();
            }

        }
    }
}
