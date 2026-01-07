using DayOffMini.Domain.DTOs;
using DayOffMini.Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace DayOffMini.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestsController : ControllerBase
    {
        private readonly ILeaveRequestService _leaveRequestService;

        public LeaveRequestsController(ILeaveRequestService leaveRequestService)
        {
            _leaveRequestService = leaveRequestService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateLeaveRequestDto dto)
        {
            await _leaveRequestService.CreateAsync(dto);
            return Ok("leave request created successfully");
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] LeaveRequestDto dto)
        {

            await _leaveRequestService.UpdateAsync(dto);
            return Ok("leave request updated successfully");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var dto = await _leaveRequestService.GetByIdAsync(id);
            return Ok(dto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var dtos = await _leaveRequestService.GetAllAsync();
            return Ok(dtos);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _leaveRequestService.DeleteAsync(id);
            return Ok("leave request deleted successfully");
        }
    }
}
