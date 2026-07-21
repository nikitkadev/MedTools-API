using MediatR;

using Web.Dtos.Requests.RConrtol;
using Web.Registration.Endpoints;

namespace Web.Endpoints.RControl;

public class RControlData : IEndpoint
{
    public void Register(IEndpointRouteBuilder endpointsBuilder)
    {
        var group = endpointsBuilder.MapGroup("/rcontrol")
            .WithTags("RControlData");

        group.MapPost("/invoices-shortly", GetInvoicesShortlyAsync);
    }

    private static async Task<IResult> GetInvoicesShortlyAsync(
        GetInvoicesShortlyRequest request,
        ISender sender,
        CancellationToken cancellationToken)
    {
        return Results.Ok();
    }
}
