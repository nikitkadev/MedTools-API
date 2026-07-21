using MediatR;
using AutoMapper;

using Application.Commands.UserManagment.UserRegistration;
using Application.Commands.Auth.Login;

using Web.Registration.Endpoints;
using Web.Dtos.Requests;


namespace Web.Endpoints.Users;

public class UserAuthorization : IEndpoint
{
    public void Register(IEndpointRouteBuilder endpointsBuilder)
    {
        var group = endpointsBuilder
            .MapGroup("/auth")
            .WithTags("Authentication");

        group.MapPost("/register", RegisterAsync);
        group.MapPost("/login", LoginAsync);
    }

    private static async Task<IResult> RegisterAsync(
        UserRegisterRequest request,
        ISender sender,
        IMapper mapper,
        ILogger<UserAuthorization> logger,
        CancellationToken cancellationToken)
    {
        var mapCommand = mapper.Map<UserRegistrationCommand>(request);
        var result = await sender.Send(mapCommand, cancellationToken);

        if (result.IsSuccess)
        {
            return Results.Ok(
                new
                {
                    result.IsSuccess,
                    result.ClientMessage
                });
        }

        return Results.BadRequest(
            new
            {
                result.IsSuccess,
                result.ClientMessage
            });
        
    } 

    private static async Task<IResult> LoginAsync(
        UserLoginRequest request,
        ISender sender,
        IMapper mapper,
        ILogger<UserAuthorization> logger,
        CancellationToken cancellationToken)
    {
        var mapCommand = mapper.Map<LoginCommand>(request);
        var result = await sender.Send(mapCommand, cancellationToken);


        if (result.IsSuccess)
        {
            return Results.Ok(
                new
                {
                    result.IsSuccess,
                    result.Value
                });
        }

        return Results.BadRequest(
            new
            {
                result.IsSuccess,
                result.Value
            });
    }
}