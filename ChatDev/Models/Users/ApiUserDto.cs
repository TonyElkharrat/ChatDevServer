using System.ComponentModel.DataAnnotations;

namespace ChatDev.Models.Users
{
    public class ApiUserDto : LoginDto
    {
        [Required]
        [LetterValidation(@"^[a-zA-Z]*$", ErrorMessage = "Only letters are allowed.")]
        public string FirstName { get; set; }
        [Required]
        [LetterValidation(@"^[a-zA-Z]*$", ErrorMessage = "Only letters are allowed.")]
        public string LastName { get; set; }
       
    }
}
