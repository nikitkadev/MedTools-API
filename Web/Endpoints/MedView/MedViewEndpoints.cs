using Web.Registration.Endpoints;
using Web.Endpoints.MedView.Sources;

namespace Web.Endpoints.MedView;

public class MedViewEndpoints : IEndpoint
{
    public void Register(IEndpointRouteBuilder endpointsBuilder)
    {
        var group = endpointsBuilder
            .MapGroup("/med-view")
            .WithTags("MedView")
            .RequireAuthorization();

        group.MapFilterOptionsEndpoints();
        group.MapCompletedCaseEndpoints();
    }

}