using DayOffMini.Domain.DTOs;
using DayOffMini.Domain.DTOs.CreateRequests;
using DayOffMini.Domain.DTOs.Reports;
using DayOffMini.Domain.DTOs.UpdateRequests;
using DayOffMini.Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DayOffMini.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly ILeaveBalanceService _leaveBalanceService;
        private readonly ILeaveRequestService _leaveRequestService;

        public EmployeesController(IEmployeeService employeeService, ILeaveBalanceService leaveBalanceService, ILeaveRequestService leaveRequestService)
        {
            _employeeService = employeeService;
            _leaveBalanceService = leaveBalanceService;
            _leaveRequestService = leaveRequestService;
        }

        #region Employees
        [HttpPost]
        //[Authorize(Policy = "HRManagerOnly")]
        public async Task<IActionResult> Create([FromBody] CreateEmployeeDto dto)
        {
            await _employeeService.CreateAsync(dto);
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateEmployeeNameDto dto)
        {
            await _employeeService.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            EmployeeDto? employeeDto = await _employeeService.GetByIdAsync(id);
            if (employeeDto == null)
            {
                return NotFound("employee not found");
            }
            return Ok(employeeDto);
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            ICollection<EmployeeDto> dtos = await _employeeService.GetAllAsync();
            return Ok(dtos);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _employeeService.DeleteAsync(id);
            return NoContent();
        }
        #endregion

        #region Leave Balances
        [HttpGet("{employeeId}/LeaveBalances")]
        public async Task<IActionResult> GetEmployeeLeaveBalances(int employeeId)
        {
            ICollection<LeaveBalanceDto> dtos = await _leaveBalanceService.GetEmployeeLeaveBalancesAsync(employeeId);
            if (!dtos.Any())
                return NoContent();

            return Ok(dtos);
        }

        [HttpPut("{employeeId}/LeaveBalances/{leaveBalanceId}")]
        public async Task<IActionResult> UpdateEmployeeLeaveBalance(int employeeId, int leaveBalanceId, [FromBody] UpdateLeaveBalanceDto dto)
        {
            await _leaveBalanceService.UpdateEmployeeLeaveBalanceAsync(employeeId, leaveBalanceId, dto);
            return NoContent();
        }
        #endregion

        #region Leave Requests
        [HttpPost("{employeeId}/LeaveRequests")]
        public async Task<IActionResult> CreateLeaveRequest(int employeeId, [FromBody] CreateLeaveRequestDto dto)
        {
            await _leaveRequestService.CreateAsync(employeeId, dto);
            return Created();
        }

        [HttpGet("{employeeId}/LeaveRequests")]
        public async Task<IActionResult> GetEmployeeLeaveRequests(int employeeId)
        {
            ICollection<LeaveRequestDto> dtos = await _leaveRequestService.GetEmployeeLeaveRequestsAsync(employeeId);
            return Ok(dtos);
        }

        [HttpPut("{employeeId}/LeaveRequests/{leaveRequestId}")]
        public async Task<IActionResult> UpdateEmployeeLeaveRequest(int employeeId, int leaveRequestId, [FromBody] UpdateLeaveRequestDto dto)
        {
            await _leaveRequestService.UpdateEmployeeLeaveRequestAsync(employeeId, leaveRequestId, dto);
            return NoContent();
        }

        [HttpDelete("{employeeId}/LeaveRequests/{leaveRequestId}")]
        public async Task<IActionResult> DeleteEmployeeLeaveRequest(int employeeId, int leaveRequestId)
        {
            await _leaveRequestService.DeleteAsync(employeeId, leaveRequestId);
            return NoContent();
        }
        #endregion

        [HttpGet("LeaveBalances/Report")]
        public async Task<IActionResult> LeaveBalancesReport()
        {
            ICollection<LeaveBalancesReportDto> report = await _leaveBalanceService.GetLeaveBalancesReportAsync();
            return Ok(report);
        }
    }
}
