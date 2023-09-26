using Microsoft.AspNetCore.Identity;

namespace ChatDev.Data
{
    public class ApiUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilPhoto { get; set; }

    }
}
