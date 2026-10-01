using MediatR;

using Application.Queries.MedView.CompletedCases.GetCompletedCasesQuery;

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
                TargetDb: request.TargetDb,
                Filters: request.Filters,
                Page: request.Pagination.Page,
                PageSize: request.Pagination.PageSize),
            cancellationToken: cancellationToken);

        if (result.IsFailure)
        {
            Results.BadRequest();
        }

        return Results.Ok(result);
    }
}
