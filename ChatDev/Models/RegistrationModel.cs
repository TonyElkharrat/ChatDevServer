using ChatDev.Annotations;
using System.ComponentModel.DataAnnotations;

namespace ChatDev.Models
{
    public class RegistrationModel
    {
        [Required]
        public string CaptchaToken { get; set; }
    }
}
