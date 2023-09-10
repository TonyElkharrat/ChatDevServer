using ChatDev.Annotations;
using System.ComponentModel.DataAnnotations;

namespace ChatDev.Models
{
    public class LoginModel
    {
        [Required]
        [EmailAddress(ErrorMessage = "The Email field is not a valid email address.")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [PasswordRequirements]
        public string Password { get; set; }
    }
}
