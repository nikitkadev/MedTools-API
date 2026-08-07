using MediatR;

using Core.Enums;

using Application.Queries.RContol.Oncology.GetMedicationsQuery;

namespace Web.Endpoints.RControl.Oncology;

public static class OncologyServiceEndpoints
{
    public static void MapOncologyServiceEndpoints(this RouteGroupBuilder builder)
    {
        var group = builder.MapGroup("/oncology-services").WithTags("RControl Oncology Services");

        group.MapGet("/{oncologyServiceUid}/medications", GetMedicationsAsync);
        
    } 

    private static async Task<IResult> GetMedicationsAsync(
        int oncologyServiceUid,
        TargetDbType targetDb,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            request: new GetMedicationsQuery(
                OncologyServiceUid: oncologyServiceUid,
                TargetDb: targetDb),
            cancellationToken: cancellationToken);

        if (result.IsFailure)
        {
            return Results.BadRequest(result);
        }

        return Results.Ok(result);
    }
}
