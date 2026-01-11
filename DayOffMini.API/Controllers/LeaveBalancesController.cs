using DayOffMini.Domain.DTOs;
using DayOffMini.Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace DayOffMini.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveBalancesController : ControllerBase
    {
        private readonly ILeaveBalanceService _leaveBalanceService;

        public LeaveBalancesController(ILeaveBalanceService leaveBalanceService)
        {
            _leaveBalanceService = leaveBalanceService;
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] LeaveBalanceDto dto)
        {
            var existingLeaveBalance = await _leaveBalanceService.GetByIdAsync(dto.Id);
            if (existingLeaveBalance == null)
            {
                return BadRequest("leave balance not found");
            }
            await _leaveBalanceService.UpdateAsync(dto);
            return Ok("leave balanace updated successfully");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var leaveBalanceDto = await _leaveBalanceService.GetByIdAsync(id);
            if (leaveBalanceDto == null)
            {
                return NotFound("leave balance not found");
            }
            return Ok(leaveBalanceDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var dtos = await _leaveBalanceService.GetAllAsync();
            if (!dtos.Any())
                return NoContent();

            return Ok(dtos);
        }
    }
}
