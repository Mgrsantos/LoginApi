using LoginApi.DTOs;
using LoginApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace LoginApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterDto dto)
        {
            var token = _authService.Register(dto);
            if (token == null)
                return BadRequest("Usuário já existe.");

            return Ok(new { token });
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            var token = _authService.Login(dto);
            if (token == null)
                return Unauthorized("Usuário ou senha inválidos.");

            return Ok(new { token });
        }
    }
}
