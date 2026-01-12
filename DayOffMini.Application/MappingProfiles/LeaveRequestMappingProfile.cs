using AutoMapper;
using DayOffMini.Domain.DTOs;
using DayOffMini.Domain.DTOs.CreateRequests;
using DayOffMini.Domain.DTOs.UpdateRequests;
using DayOffMini.Domain.Models;

namespace DayOffMini.Application.MappingProfiles
{
    public class LeaveRequestMappingProfile : Profile
    {
        public LeaveRequestMappingProfile()
        {
            CreateMap<LeaveRequestDto, LeaveRequest>().ReverseMap()
                .ForMember(dest => dest.EmployeeName, op => op.MapFrom(src => src.Employee.Name))
                .ForMember(dest => dest.LeaveTypeName, op => op.MapFrom(src => src.LeaveType.Name))
                .ForMember(dest => dest.LeaveRequestStatusName, op => op.MapFrom(src => src.LeaveRequestStatus.Name));

            CreateMap<LeaveRequest, CreateLeaveRequestDto>().ReverseMap();

            CreateMap<LeaveRequest, UpdateLeaveRequestDto>().ReverseMap();
        }
    }
}
