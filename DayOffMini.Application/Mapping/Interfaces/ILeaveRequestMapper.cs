using DayOffMini.Application.DTOs;
using DayOffMini.Domain.Models;

namespace DayOffMini.Application.Mapping.Interfaces
{
    public interface ILeaveRequestMapper
    {
        LeaveRequestDto ToDto(LeaveRequest leaveRequest);
        LeaveRequest ToEntity(LeaveRequestDto dto);
    }
}
