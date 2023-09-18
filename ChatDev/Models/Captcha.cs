using System.ComponentModel.DataAnnotations;

namespace ChatDev.Models
{
    public class Captcha
    {
        [Required]
        public string CaptchaToken { get; set; }
    }
}
