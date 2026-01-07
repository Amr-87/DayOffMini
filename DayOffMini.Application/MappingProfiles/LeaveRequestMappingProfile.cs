using AutoMapper;
using DayOffMini.Domain.DTOs;
using DayOffMini.Domain.Models;

namespace DayOffMini.Application.MappingProfiles
{
    public class LeaveRequestMappingProfile : Profile
    {
        public LeaveRequestMappingProfile()
        {
            CreateMap<LeaveRequest, LeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequest, CreateLeaveRequestDto>().ReverseMap();
        }
    }
}
