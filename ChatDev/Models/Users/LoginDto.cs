using System.ComponentModel.DataAnnotations;

namespace ChatDev.Models.Users
{
    public class LoginDto
    {
        [Required]
        [LetterValidation(@"^[a-zA-Z]*$", ErrorMessage = "Only letters are allowed.")]
        public string FirstName { get; set; }
        [Required]
        [LetterValidation(@"^[a-zA-Z]*$", ErrorMessage = "Only letters are allowed.")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
       
    }
}
