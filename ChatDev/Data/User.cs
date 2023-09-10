using ChatDev.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;

namespace ChatDev.Data
{
    public class User
    {
        [Required]
        [LetterValidation(@"^[a-zA-Z]*$", ErrorMessage = "Only letters are allowed.")]
        public string FirstName { get; set; }
        [Required]
        [LetterValidation(@"^[a-zA-Z]*$", ErrorMessage = "Only letters are allowed.")]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [PasswordRequirements]
        public string Password { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "The Email field is not a valid email address.")]
        public string Email { get; set; }
    }
}
