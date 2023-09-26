using ChatDev.Contracts;
using ChatDev.Exceptions;
using ChatDev.Models.Users;
using ChatDev.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatDev.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthManager _authManager;
        private readonly IConfiguration _configuration;

        public AccountController(IAuthManager authManager,IConfiguration configuration)
        {
            this._authManager = authManager;
            this._configuration = configuration;
        }

        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Register([FromBody] ApiUserDto apiUserDto)
        {
            var errors = await _authManager.Register(apiUserDto);
            if (errors.Any())
            {
                foreach (var error in errors)
                {
                    ModelState.AddModelError(error.Code,error.Description);
                }

                return BadRequest(ModelState);
            }

            return Ok();
        }

        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Login([FromBody] ApiUserDto apiUserDto)
        {
            var authResponse  = await _authManager.Login(apiUserDto);
            if (authResponse == null)
            {
                throw new UnauthorizedException("Login Failed");
            }

            return Ok(authResponse);
        }

        [HttpPost]
        [Route("login-with-google")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> LoginWithGoogle([FromBody] GoogleAuthDto googleAuthDto)
        {
            var authResponse = await _authManager.AuthenticateWithGoogle(googleAuthDto);
            if (authResponse == null)
            {
                throw new UnauthorizedException("Login Failed");
            }

            return Ok(authResponse);
        }


        [HttpPost]
        [Route("refreshtoken")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> RefreshToken([FromBody] AuthResponseDto authResponseDto)
        {
            var authResponse = await _authManager.VerifyRefreshToken(authResponseDto);
            if (authResponse == null)
            {
                return Unauthorized();
            }

            return Ok(authResponse);
        }

        [HttpPost]
        [Route("forgot-password")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> ForgotPassword([FromBody] string email)
        {
            var emailSender = new EmailSender(_configuration);
            emailSender.SendEmail(email,EmailType.ForgotPassword);

            return Ok();
        }
    }
}
