using AutoMapper;
using PrenticeApi.Dtos;
using PrenticeApi.Models;

namespace PrenticeApi.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ApplicationUser, UserDto>();
            CreateMap<UserDto, ApplicationUser>();
        }
    }
}