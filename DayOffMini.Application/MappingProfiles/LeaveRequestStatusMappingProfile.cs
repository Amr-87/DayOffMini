using AutoMapper;
using DayOffMini.Domain.DTOs;
using DayOffMini.Domain.Models;

namespace DayOffMini.Application.MappingProfiles
{
    public class LeaveRequestStatusMappingProfile : Profile
    {
        public LeaveRequestStatusMappingProfile()
        {
            CreateMap<LeaveRequestStatus, LeaveRequestStatusDto>().ReverseMap();
        }
    }
}
