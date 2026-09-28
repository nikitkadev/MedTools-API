using Application.Queries.MedView.CompletedCases.GetCompletedCasesQuery;
using MediatR;

using Web.Dtos.Requests.MedView;

namespace Web.Endpoints.MedView.Sources;

public static class CompletedCaseEndpoints
{
    public static void MapCompletedCaseEndpoints(this RouteGroupBuilder builder)
    {
        var group = builder.MapGroup("/completed-cases").WithTags("RControl Completed Cases");

        group.MapPost("", GetCompletedCasesAsync);
    }

    private static async Task<IResult> GetCompletedCasesAsync(
        GetCompletedCasesRequest request,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetCompletedCasesQuery(
                TargetDb: Core.Common.Enums.TargetDbType.SMODB18,
                request.Filters),
            cancellationToken: cancellationToken);

        if (result.IsFailure)
        {
            Results.BadRequest();
        }

        return Results.Ok(result);
    }
}
