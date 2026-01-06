using AutoMapper;
using DayOffMini.Domain.DTOs;
using DayOffMini.Domain.Models;

namespace DayOffMini.Application.MappingProfiles
{
    public class LeaveBalanceMappingProfile : Profile
    {
        public LeaveBalanceMappingProfile()
        {
            CreateMap<LeaveBalance, LeaveBalanceDto>().ReverseMap();
        }
    }
}
