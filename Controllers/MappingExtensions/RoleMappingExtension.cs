using DayOffMini.Controllers.DTOs;
using DayOffMini.Data.Models;

namespace DayOffMini.Controllers.MappingExtensions
{
    public static class RoleMappingExtension
    {
        public static RoleDto ToDto(this Role role)
        {
            return new RoleDto
            {
                Id = role.Id,
                Name = role.Name
            };
        }

        public static Role ToEntity(this RoleDto dto)
        {
            return new Role
            {
                Id = dto.Id,
                Name = dto.Name,
            };
        }
    }
}
