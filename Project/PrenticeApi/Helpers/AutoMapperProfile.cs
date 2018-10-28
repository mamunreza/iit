using AutoMapper;
using PrenticeApi.Dtos;
using PrenticeApi.Entities;

namespace PrenticeApi.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}