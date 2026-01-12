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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var dto = await _leaveRequestStatusService.GetByIdAsync(id);
            if (dto == null)
            {
                return NotFound("leave request status not found");
            }
            return Ok(dto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var dtos = await _leaveRequestStatusService.GetAllAsync();
            return Ok(dtos);
        }
    }
}
