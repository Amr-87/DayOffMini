using DayOffMini.Controllers.DTOs;
using DayOffMini.Controllers.Mapping.Interfaces;
using DayOffMini.Data.Models;

namespace DayOffMini.Controllers.Mapping.Implementations
{
    public class LeaveRequestMapper : ILeaveRequestMapper
    {
        public LeaveRequestDto ToDto(LeaveRequest leaveRequest)
        {
            return new LeaveRequestDto
            {
                Id = leaveRequest.Id,
                EmployeeId = leaveRequest.EmployeeId,
                LeaveTypeId = leaveRequest.LeaveTypeId,
                LeaveRequestStatusId = leaveRequest.LeaveRequestStatusId,
                StartDate = leaveRequest.StartDate,
                EndDate = leaveRequest.EndDate,
                Reason = leaveRequest.Reason
            };
        }

        public LeaveRequest ToEntity(LeaveRequestDto dto)
        {
            return new LeaveRequest
            {
                Id = dto.Id,
                EmployeeId = dto.EmployeeId,
                LeaveTypeId = dto.LeaveTypeId,
                LeaveRequestStatusId = dto.LeaveRequestStatusId,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Reason = dto.Reason
            };
        }
    }
}
