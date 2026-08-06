using MediatR;

using Core.Enums;

using Application.Queries.RContol.Workspace.CompletedCases.GetCompletedCasesQuery;
using Application.Queries.RContol.Workspace.CompletedCases.GetCompletedCaseDetailsQuery;

namespace Web.Endpoints.RControl.Workspace;

public static class CompletedCaseEndpoints
{
    public static void MapCompletedCaseEndpoints(this RouteGroupBuilder builder)
    {
        var group = builder.MapGroup("/completed-cases").WithTags("RControl Completed Cases");

        group.MapGet("", GetCompletedCasesAsync);
        group.MapGet("/{completedCaseUid:int}", GetCompletedCaseDetailsAsync);

    }

    private static async Task<IResult> GetCompletedCasesAsync(
        int invoiceUid,
        int page,
        int pageSize,
        TargetDbType targetDb,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            request: new GetCompletedCasesQuery(
                InvoiceUid: invoiceUid,
                Page: page,
                PageSize: pageSize,
                TargetDb: targetDb),
            cancellationToken: cancellationToken);

        if (result.IsFailure)
        {
            return Results.BadRequest(result);
        }

        return Results.Ok(result);
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
                TargetDb: targetDb));

        if (result.IsFailure)
        {
            return Results.BadRequest(result);
        }

        return Results.Ok(result);
    }

}