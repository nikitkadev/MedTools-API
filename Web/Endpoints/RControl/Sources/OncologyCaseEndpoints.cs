using MediatR;

using Core.Common.Enums;

using Application.Queries.RContol.OncologyCases.GetDignosticsQuery;
using Application.Queries.RContol.OncologyCases.GetOncologyServicesQuery;
using Application.Queries.RContol.OncologyCases.GetContraindicationsQuery;

namespace Web.Endpoints.RControl.Sources;

public static class OncologyCaseEndpoints
{
    public static void MapOncologyCaseEndpoints(this RouteGroupBuilder builder)
    {
        var group = builder.MapGroup("/oncology-cases").WithTags("RControl Oncology Cases");

        group.MapGet("/{oncologyCaseUid:int}/сontraindications", GetContraindicationsAsync);
        group.MapGet("/{oncologyCaseUid:int}/diagnostics", GetDiagnosticsAsync);
        group.MapGet("/{oncologyCaseUid:int}/oncology-services", GetOncologyServicesAsync);
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

    private static async Task<IResult> GetDiagnosticsAsync(
        int oncologyCaseUid,
        TargetDbType targetDb,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            request: new GetDignosticsQuery(
                OncologyCaseUid: oncologyCaseUid,
                TargetDb: targetDb),
            cancellationToken: cancellationToken);

        if (result.IsFailure)
        {
            return Results.BadRequest(result);
        }

        return Results.Ok(result);
    }

    private static async Task<IResult> GetOncologyServicesAsync(
        int oncologyCaseUid,
        TargetDbType targetDb,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            request: new GetOncologyServicesQuery(
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