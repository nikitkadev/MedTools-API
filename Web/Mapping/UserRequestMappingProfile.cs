using AutoMapper;

using Web.Dtos.Requests;
using Application.Queries.UserManagment.UserRegistration;
using Application.Queries.Auth.Login;

namespace Web.Mapping;

public class UserRequestMappingProfile : Profile
{
    public UserRequestMappingProfile()
    {
        CreateMap<UserRegisterRequest, UserRegistrationCommand>();
        CreateMap<UserLoginRequest, LoginCommand>();
    }
}
