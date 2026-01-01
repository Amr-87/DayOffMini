using DayOffMini.Controllers.DTOs;
using DayOffMini.Data.Models;
using DayOffMini.Services.Generic;
using Microsoft.AspNetCore.Mvc;

namespace DayOffMini.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IGenericService<User> _userGenericService;

        public AuthController(IGenericService<User> userGenericService)
        {
            _userGenericService = userGenericService;
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserDto user)
        {
            await _userGenericService.CreateAsync(new User
            {
                RoleId = user.RoleId,
                Email = user.Email,
                Name = user.Name,
                Password = user.Password
            });
            return Ok();
        }
    }
}
