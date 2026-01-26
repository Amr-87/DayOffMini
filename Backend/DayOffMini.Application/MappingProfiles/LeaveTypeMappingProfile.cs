using AutoMapper;
using DayOffMini.Domain.DTOs;
using DayOffMini.Domain.DTOs.UpdateRequests;
using DayOffMini.Domain.Models;

namespace DayOffMini.Application.MappingProfiles
{
    public class LeaveTypeMappingProfile : Profile
    {
        public LeaveTypeMappingProfile()
        {
            CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();

            CreateMap<LeaveType, UpdateLeaveTypeDto>().ReverseMap();
        }
    }
}
