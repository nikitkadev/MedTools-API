using AutoMapper;

using Core.Entities;
using Infrastructure.Database.DbEntities;

namespace Infrastructure.Mapping;

public class UserEntityMappingProfile : Profile
{
    public UserEntityMappingProfile()
    {
        CreateMap<User, UserDbEntity>().ReverseMap();
    }
}
