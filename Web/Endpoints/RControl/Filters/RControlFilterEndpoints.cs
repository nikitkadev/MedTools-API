using MediatR;

using Core.Enums;

using Application.Queries.RContol.Filters.GetMedicalOrganizationsQuery;
using Application.Queries.RContol.Filters.GetPeriodsCommand;

namespace Web.Endpoints.RControl.Filters;

public static class RControlFilterEndpoints
{
    public static void MapFilters(this RouteGroupBuilder builder)
    {
        var filtersGroup = builder.MapGroup("filters").WithTags("RControl Filters");

        filtersGroup.MapGet("/medical-organizations", GetMedicalOrganizationsQueryHandler);
        filtersGroup.MapGet("/billing-periods", GetBillingPeriodsQueryHandler);
    }

    private static async Task<IResult> GetMedicalOrganizationsQueryHandler(
        TargetDbType targetDb,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            request: new GetMedicalOrganizationsQuery(TargetDb: targetDb),
            cancellationToken: cancellationToken);

        if (result.IsFailure)
        {
            return Results.BadRequest(result);
        }

        return Results.Ok(result);
    }

    private static async Task<IResult> GetBillingPeriodsQueryHandler(
        string medicalOrganizationCode,
        TargetDbType targetDb,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            new GetPeriodsCommand(
                TargetDbType: targetDb,
                OrgCode: medicalOrganizationCode),
            cancellationToken: cancellationToken);

        if (result.IsFailure)
        {
            return Results.BadRequest(result);
        }

        return Results.Ok(result);
    }
}
