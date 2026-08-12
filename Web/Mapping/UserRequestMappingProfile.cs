using AutoMapper;

using Web.Dtos.Requests;
using Application.Commands.Auth.LoginCommand;
using Application.Commands.Users.UserRegistrationCommand;

namespace Web.Mapping;

public class UserRequestMappingProfile : Profile
{
    public UserRequestMappingProfile()
    {
        CreateMap<UserRegisterRequest, UserRegistrationCommand>();
        CreateMap<UserLoginRequest, LoginCommand>();
    }
}
