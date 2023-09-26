using System.ComponentModel.DataAnnotations;

namespace ChatDev.Models.Users
{
    public class ApiUserDto : LoginDto
    {
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


    }
}
