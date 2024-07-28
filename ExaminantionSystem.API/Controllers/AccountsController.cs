using ExaminantionSystem.API.Contracts.Authentacation;
using ExaminantionSystem.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExaminantionSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AccountsController( IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterRequest request)
        {
            var result = await _authService.RegisterAsync(request);

            if ( !result)
                return BadRequest("An  Error while Register , Please try Again");

            return Ok("Email Created");
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(AuthRequest request)
        {
             var result = await _authService.GetTokenAsync(request.Email, request.Password);

            if (result is null)
                return BadRequest(" invalid email or password");

            return Ok(result);
        }
    }
}
