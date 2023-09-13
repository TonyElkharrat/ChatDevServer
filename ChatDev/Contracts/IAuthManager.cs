using ChatDev.Models.Users;

namespace ChatDev.Contracts
{
    public interface IAuthManager
    {
        Task<bool> Register(ApiUserDto userDto);
    }
}
