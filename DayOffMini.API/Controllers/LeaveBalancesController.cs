using DayOffMini.Domain.DTOs.Reports;
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

        [HttpGet("Report")]
        public async Task<IActionResult> LeaveBalancesReport()
        {
            ICollection<LeaveBalancesReportDto> report = await _leaveBalanceService.GetLeaveBalancesReportAsync();
            return Ok(report);
        }
    }
}
