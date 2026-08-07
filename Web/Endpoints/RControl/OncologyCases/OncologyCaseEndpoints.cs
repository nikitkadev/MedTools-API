using MediatR;

using Core.Enums;
using Application.Queries.RContol.Oncology.GetContraindicationsQuery;

namespace Web.Endpoints.RControl.OncologyCases;

public static class OncologyCaseEndpoints
{
    public static void MapOncologyCaseEndpoints(this RouteGroupBuilder builder)
    {
        var group = builder.MapGroup("/oncology-cases").WithTags("RControl Oncology Cases");

        group.MapGet("/{oncologyCaseUid:int}/сontraindications", GetContraindicationsAsync);
    }

    private static async Task<IResult> GetContraindicationsAsync(
        int oncologyCaseUid,
        TargetDbType targetDb,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            request: new GetContraindicationsQuery(
                OncologyCaseUid: oncologyCaseUid,
                TargetDb: targetDb),
            cancellationToken: cancellationToken);

        if (result.IsFailure)
        {
            return Results.BadRequest(result);
        }

        return Results.Ok(result);
    }

}
