using AutoMapper;

using Core.Entities;

using Infrastructure.Database.Enitites.Auth;

namespace Infrastructure.Mapping;

public class UserEntityMappingProfile : Profile
{
    public UserEntityMappingProfile()
    {
        CreateMap<User, UserEntity>().ReverseMap();
    }
}
