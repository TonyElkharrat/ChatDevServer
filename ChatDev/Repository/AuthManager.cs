using AutoMapper;
using ChatDev.Contracts;
using ChatDev.Data;
using ChatDev.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace ChatDev.Repository
{
    public class AuthManager : IAuthManager
    {
        public AuthManager(IMapper mapper,UserManager<ApiUser> userManager)
        {
         
        }

        public Task<bool> Register(ApiUserDto userDto)
        {
            throw new NotImplementedException();
        }
    }
}
