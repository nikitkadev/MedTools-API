using Web.Endpoints.RControl;
using Web.Endpoints.Users;

namespace Web.Registration.Endpoints;

public static class EndpointsProvider
{
    public static void RegisterAppEndpoints(RouteGroupBuilder routeGroupBuilder)
    {
        routeGroupBuilder.Register<UserAuthorization>();
        routeGroupBuilder.Register<RControlData>();
    }
}
