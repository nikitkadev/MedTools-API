using MediatR;

using Core.Enums;

using Application.Queries.RContol.Workspace.CompletedCases.GetCompletedCasesQuery;

namespace Web.Endpoints.RControl.Workspace;

public static class RControlCompletedCaseEndpoints
{
    public static void MapCompletedCaseEndpoints(this RouteGroupBuilder builder)
    {
        var group = builder.MapGroup("/completed-cases").WithTags("RControl Completed Cases");

        group.MapGet("", GetCompletedCasesAsync);
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

}