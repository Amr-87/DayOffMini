using DayOffMini.Domain.DTOs;
using DayOffMini.Domain.DTOs.Auth;
using DayOffMini.Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DayOffMini.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            string? token = await _authService.LoginAsync(request.Email, request.Password);
            if (token == null)
                return Unauthorized(new { Message = "Invalid credentials" });

            return Ok(new { Token = token });
        }

        [HttpGet("user/{id}")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            UserDTO? userDto = await _authService.GetUserById(id);
            if (userDto == null)
            {
                return NotFound("user not found");
            }
            return Ok(userDto);
        }

    }
}
