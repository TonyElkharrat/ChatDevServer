using AutoMapper;
using ChatDev.Algorithms;
using ChatDev.Data;
using ChatDev.Models.Messages;
using ChatDev.Models.Users;
using System.Diagnostics.Metrics;

namespace ChatDev.Configuration
{
    public class MapConfig : Profile
    {
        public MapConfig()
        {
           CreateMap<ApiUserDto, ApiUser>().ReverseMap();
           CreateMap<GoogleAuthDto, ApiUser>().ReverseMap();
           CreateMap<MessagePostDto, Message>().ReverseMap();
           CreateMap<MessageResponseDto, Message>().ReverseMap();
        }
    }
}
