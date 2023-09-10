using AutoMapper;
using ChatDev.Algorithms;
using ChatDev.Data;
using ChatDev.DTOS;
using System.Diagnostics.Metrics;

namespace ChatDev.Configuration
{
    public class MapConfig : Profile
    {
        public MapConfig()
        {
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Password, opt =>
                    opt.MapFrom(src => PasswordHasher.HashPassword(src.Password))); // Map and hash the password from User to UserDto
        }
    }


    public class PasswordHashValueResolver : IValueResolver<UserDto, User, string>
    {
        public string Resolve(UserDto source, User destination, string destMember, ResolutionContext context)
        {
            // Call your HashPassword method here and return the hashed password
            return PasswordHasher.HashPassword(source.Password); // Replace with your actual logic
        }
    }
}
