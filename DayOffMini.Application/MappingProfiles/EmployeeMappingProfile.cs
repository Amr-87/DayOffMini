using AutoMapper;
using DayOffMini.Domain.DTOs;
using DayOffMini.Domain.Models;

namespace DayOffMini.Application.MappingProfiles
{
    public class EmployeeMappingProfile : Profile
    {
        public EmployeeMappingProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();

            CreateMap<Employee, CreateEmployeeDto>().ReverseMap();

            CreateMap<Employee, UpdateEmployeeDto>().ReverseMap();

        }
    }
}
