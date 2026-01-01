using DayOffMini.Controllers.DTOs;
using DayOffMini.Controllers.MappingExtensions;
using DayOffMini.Data.Models;
using DayOffMini.Services.Generic;
using Microsoft.AspNetCore.Mvc;

namespace DayOffMini.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IGenericService<Role> _genericService;

        public RolesController(IGenericService<Role> genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleDto dto)
        {
            await _genericService.CreateAsync(dto.ToEntity());
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRole(RoleDto dto)
        {
            try
            {
                await _genericService.UpdateAsync(dto.ToEntity());
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        [HttpGet("{roleId}")]
        public async Task<IActionResult> GetRoleById(int roleId)
        {
            var role = await _genericService.GetByIdAsync(roleId);
            if (role == null)
            {
                return NotFound();
            }
            return Ok(role.ToDto());
        }
        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            var roles = await _genericService.GetAllAsync();
            var dtoList = roles.Select(p => p.ToDto()).ToList();
            return Ok(dtoList);
        }

        [HttpDelete("{roleId}")]
        public async Task<IActionResult> DeleteRole(int roleId)
        {
            try
            {
                await _genericService.DeleteAsync(roleId);
                return Ok();
            }
            catch (ArgumentNullException ex)
            {
                return NotFound();
            }
        }

    }
}
