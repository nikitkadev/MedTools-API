using MediatR;

using Core.Enums;

using Application.Queries.RContol.ProvidedServices.GetMedicalDevicesQuery;

namespace Web.Endpoints.RControl.ProvidedServices;

public static class ProvidedServiceEndpoints
{
    public static void MapProvidedServiceEndpoints(this RouteGroupBuilder builder)
    {
        var group = builder.MapGroup("/provided-services").WithTags("RControl Provided Services");

        group.MapGet("/{providedSerivceUid:int}/medical-devices", GetMedicalDevicesAsync);
    }

    private static async Task<IResult> GetMedicalDevicesAsync(
        int providedSerivceUid,
        TargetDbType targetDb,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            request: new GetMedicalDevicesQuery(
                ProvidedServiceUid: providedSerivceUid,
                TargetDb: targetDb),
            cancellationToken: cancellationToken);

        if (result.IsFailure)
        {
            return Results.BadRequest(result);
        }

        return Results.Ok(result);
    }

}