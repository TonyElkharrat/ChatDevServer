using System.ComponentModel.DataAnnotations;

namespace ChatDev.Models.Users
{
    public class LoginDto
    {
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
