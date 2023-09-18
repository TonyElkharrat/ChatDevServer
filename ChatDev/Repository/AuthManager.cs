using AutoMapper;
using ChatDev.Contracts;
using ChatDev.Data;
using ChatDev.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static Google.Cloud.RecaptchaEnterprise.V1.TransactionData.Types;

namespace ChatDev.Repository
{
    public class AuthManager : IAuthManager
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApiUser> _userManager;
        private readonly IConfiguration _configuration;
        private ApiUser _user;
        private readonly string _loginProvider = "ChatDevApi";
        private readonly string _refreshToken = "RefreshToken";

        public AuthManager(IMapper mapper, UserManager<ApiUser> userManager, IConfiguration configuration)
        {
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<string> CreateRefreshToken()
        {
            await _userManager.RemoveAuthenticationTokenAsync(_user, _loginProvider, _refreshToken);
            var newRefreshToken = await _userManager.GenerateUserTokenAsync(_user, _loginProvider, _refreshToken);
            var result = await _userManager.SetAuthenticationTokenAsync(_user, _loginProvider, _refreshToken, newRefreshToken);
            return newRefreshToken;
        }

        public async Task<AuthResponseDto> Login(LoginDto loginDto)
        {
            _user = await _userManager.FindByEmailAsync(loginDto.Email);
            bool isValidUser = await _userManager.CheckPasswordAsync(_user, loginDto.Password);

            if (_user == null || !isValidUser)
            {
                return null;
            }

            return new AuthResponseDto()
            {
                Token =  await GenerateToken(),
                UserId = _user.Id,
                RefreshToken = await CreateRefreshToken(),
            };
        }

        public async Task<IEnumerable<IdentityError>> Register(ApiUserDto userDto)
        {
            var user = _mapper.Map<ApiUser>(userDto);
            user.UserName = userDto.Email;

            var result = await _userManager.CreateAsync(user, userDto.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
            }
            return result.Errors;
        }

        public async Task<AuthResponseDto> VerifyRefreshToken(AuthResponseDto request)
        {
            var jwtSecutiryTokenHandler = new JwtSecurityTokenHandler();
            var jwtRequestContent = jwtSecutiryTokenHandler.ReadJwtToken(request.Token);
            var userName = jwtRequestContent.Claims.ToList().FirstOrDefault(q => q.Type ==
            JwtRegisteredClaimNames.Email)?.Value;
            _user = await _userManager.FindByEmailAsync(userName);

            if(_user == null)
            {
                return null;
            }

            var isRefreshTokenValid = await _userManager.VerifyUserTokenAsync(_user,_loginProvider,_refreshToken, request.RefreshToken);

            if(isRefreshTokenValid)
            {
                var token = await  GenerateToken();
                return new AuthResponseDto()
                {
                    Token = token,
                    UserId = _user.Id,
                    RefreshToken = await CreateRefreshToken()
                };
            }

            await _userManager.UpdateSecurityStampAsync(_user);

            return null;
        }

        private async Task<string> GenerateToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var roles = await _userManager.GetRolesAsync(_user);
            var roleClaims = roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList();
            var userClaims = await _userManager.GetClaimsAsync(_user);
            var claims = new List<Claim>()
                {
                 new Claim(ClaimTypes.NameIdentifier,_user.Email),
                    new Claim(JwtRegisteredClaimNames.Sub,_user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, new Guid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email,_user.Email),
                }.Union(userClaims).Union(roleClaims);
        
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
