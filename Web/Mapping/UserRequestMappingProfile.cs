using AutoMapper;

using Web.Dtos.Requests;
using Application.Queries.UserManagment.UserRegistration;
using Application.Commands.Auth.Login;

namespace Web.Mapping;

public class UserRequestMappingProfile : Profile
{
    public UserRequestMappingProfile()
    {
        CreateMap<UserRegisterRequest, UserRegistrationCommand>();
        CreateMap<UserLoginRequest, LoginCommand>();
    }
}
