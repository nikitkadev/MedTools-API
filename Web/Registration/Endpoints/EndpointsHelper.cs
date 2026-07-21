namespace Web.Registration.Endpoints;

public static class EndpointsHelper
{
    public static IEndpointRouteBuilder Register<T>(this IEndpointRouteBuilder endpointsBuilder) 
        where T : IEndpoint, new()
    {
        var endpointsProvider = new T();
        endpointsProvider.Register(endpointsBuilder);
        return endpointsBuilder;
    }
}