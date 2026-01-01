using DayOffMini.Controllers.DTOs;
using DayOffMini.Data.Models;

namespace DayOffMini.Controllers.MappingExtensions
{
    public static class LeaveRequestMappingExtensions
    {
        public static LeaveRequestDto ToDto(this LeaveRequest? leaveRequest)
        {
            if (leaveRequest == null)
            {
                throw new ArgumentNullException();
            }
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

        public static LeaveRequest ToEntity(this LeaveRequestDto dto)
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
