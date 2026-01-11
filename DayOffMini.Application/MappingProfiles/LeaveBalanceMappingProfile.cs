using AutoMapper;
using DayOffMini.Domain.DTOs;
using DayOffMini.Domain.Models;

namespace DayOffMini.Application.MappingProfiles
{
    public class LeaveBalanceMappingProfile : Profile
    {
        public LeaveBalanceMappingProfile()
        {
            CreateMap<LeaveBalanceDto, LeaveBalance>().ReverseMap()
                .ForMember(dest => dest.EmployeeName, op => op.MapFrom(src => src.Employee.Name))
                .ForMember(dest => dest.LeaveTypeName, op => op.MapFrom(src => src.LeaveType.Name));
        }
    }
}
