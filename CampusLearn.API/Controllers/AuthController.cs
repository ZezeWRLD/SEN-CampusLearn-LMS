using CampusLearn.Application.Services.Interfaces;
using CampusLearn.Application.Services.Implementations;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using CampusLearn.Application.DTOs;

namespace CampusLearn.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
            LoginRequestDto loginRequestDto = new LoginRequestDto
            {
                UserEmail = request.Email,
                Password = request.Password
            };
            var result = await _authService.LoginAsync(loginRequestDto);

            if (result == null)
                return Unauthorized(new { message = "Invalid credentials" });

            return Ok(new { result });
        }
    }
}
