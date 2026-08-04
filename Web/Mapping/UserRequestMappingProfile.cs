using AutoMapper;

using Web.Dtos.Requests;
using Application.Commands.Auth.Login;
using Application.Commands.UserManagment.UserRegistration;

namespace Web.Mapping;

public class UserRequestMappingProfile : Profile
{
    public UserRequestMappingProfile()
    {
        CreateMap<UserRegisterRequest, UserRegistrationCommand>();
        CreateMap<UserLoginRequest, LoginCommand>();
    }
}
