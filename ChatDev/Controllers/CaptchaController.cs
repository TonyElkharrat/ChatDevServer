using ChatDev.Models;
using ChatDev.Third_Party;
using Microsoft.AspNetCore.Mvc;

namespace ChatDev.Controllers
{
    public class CaptchaController : Controller
    {
        private readonly IConfiguration _configuration;
        public CaptchaController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost("captcha")]
        public async Task<IActionResult> ValidateCaptcha(Captcha captcha)
        {
            var captchaResponse = await CaptchaValidation.IsCaptchaTokenValidAsync(captcha.CaptchaToken, _configuration);
            if (!captchaResponse)
            {
                return BadRequest("Captcha Not Valid");
            }

            return Ok();
        }
    }
}
