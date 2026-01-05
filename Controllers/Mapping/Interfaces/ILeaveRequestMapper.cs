using DayOffMini.Controllers.DTOs;
using DayOffMini.Data.Models;

namespace DayOffMini.Controllers.Mapping.Interfaces
{
    public interface ILeaveRequestMapper
    {
        LeaveRequestDto ToDto(LeaveRequest leaveRequest);
        LeaveRequest ToEntity(LeaveRequestDto dto);
    }
}
