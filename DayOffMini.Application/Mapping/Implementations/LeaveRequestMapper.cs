using DayOffMini.Application.DTOs;
using DayOffMini.Application.Mapping.Interfaces;
using DayOffMini.Domain.Models;

namespace DayOffMini.Application.Mapping.Implementations
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
