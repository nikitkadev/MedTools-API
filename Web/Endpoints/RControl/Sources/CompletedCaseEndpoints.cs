using MediatR;

using Core.Common.Enums;

using Application.Queries.RControl.CompletedCases.GetMedicalCasesQuery;
using Application.Queries.RControl.CompletedCases.GetCompletedCaseDetailsQuery;

namespace Web.Endpoints.RControl.Sources;

public static class CompletedCaseEndpoints
{
    public static void MapCompletedCaseEndpoints(this RouteGroupBuilder builder)
    {
        var group = builder.MapGroup("/completed-cases").WithTags("RControl Completed Cases");

        group.MapGet("/{completedCaseUid:int}", GetCompletedCaseDetailsAsync);
        group.MapGet("/{completedCaseUid:int}/medical-cases", GetMedicalCasesAsync);
    }

    private static async Task<IResult> GetCompletedCaseDetailsAsync(
        int completedCaseUid,
        TargetDbType targetDb,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            request: new GetCompletedCaseDetailsQuery(
                CompletedCaseUid: completedCaseUid,
                TargetDb: targetDb),
            cancellationToken: cancellationToken);

        if (result.IsFailure)
        {
            return Results.BadRequest(result);
        }

        return Results.Ok(result);
    }

    private static async Task<IResult> GetMedicalCasesAsync(
        int completedCaseUid,
        TargetDbType targetDb,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            request: new GetMedicalCasesQuery(
                CompletedCaseUid: completedCaseUid,
                TargetDb: targetDb),
            cancellationToken: cancellationToken);

        if (result.IsFailure)
        {
            return Results.BadRequest(result);
        }

        return Results.Ok(result);
    }

}