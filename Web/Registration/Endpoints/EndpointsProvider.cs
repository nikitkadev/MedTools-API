using Web.Endpoints.Users;
using Web.Endpoints.MedView;
using Web.Endpoints.RControl;

namespace Web.Registration.Endpoints;

public static class EndpointsProvider
{
    public static void RegisterAppEndpoints(RouteGroupBuilder routeGroupBuilder)
    {
        routeGroupBuilder.Register<UserAuthorization>();
        routeGroupBuilder.Register<RControlEndpoints>();
        routeGroupBuilder.Register<MedViewEndpoints>();
    }
}
