using AutoMapper;

using Application.Commands.UserManagment.UserRegistration;
using Application.Commands.Auth.Login;

using Web.Dtos.Requests;

namespace Web.Mapping;

public class UserRequestMappingProfile : Profile
{
    public UserRequestMappingProfile()
    {
        CreateMap<UserRegisterRequest, UserRegistrationCommand>();
        CreateMap<UserLoginRequest, LoginCommand>();
    }
}
