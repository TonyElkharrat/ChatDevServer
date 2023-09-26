using ChatDev.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace ChatDev.Contracts
{
    public interface IAuthManager
    {
        Task<IEnumerable<IdentityError>> Register(ApiUserDto userDto);
        Task<AuthResponseDto> Login(ApiUserDto loginDto);
        Task<AuthResponseDto> AuthenticateWithGoogle(GoogleAuthDto googleAuthDto);
        Task<string> CreateRefreshToken();
        Task<AuthResponseDto> VerifyRefreshToken(AuthResponseDto authResponseDto);
    }
}
