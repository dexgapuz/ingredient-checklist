using api.DTO;
using api.Request;
using api.Services.Auth;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticateService _authService;

        public AuthController(IAuthenticateService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public ActionResult<AuthenticateDto> Register([FromBody] RegisterRequest registerRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var data = _authService.Register(registerRequest);

            return Ok(data);
        }
    }
}
