using DayOffMini.Domain.DTOs.Auth;
using DayOffMini.Domain.Interfaces.IServices;
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

    }
}
