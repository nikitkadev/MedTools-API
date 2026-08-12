using MediatR;

using Core.Common.Enums;

using Application.Queries.RControl.Lookups.GetBillingPeriodsQuery;
using Application.Queries.RControl.Lookups.GetMedicalOrganizationsQuery;

namespace Web.Endpoints.RControl.Sources;

public static class LookupsEndpoints
{
    public static void MapLookups(this RouteGroupBuilder builder)
    {
        var group = builder.MapGroup("lookups").WithTags("RControl Filters");

        group.MapGet("/medical-organizations", GetMedicalOrganizationsAsync);
        group.MapGet("/billing-periods", GetBillingPeriodsAsync);
    }

    private static async Task<IResult> GetMedicalOrganizationsAsync(
        TargetDbType targetDb,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            request: new GetMedicalOrganizationsQuery(
                TargetDb: targetDb), 
            cancellationToken: cancellationToken);

        if (result.IsFailure)
        {
            return Results.BadRequest(result);
        }

        return Results.Ok(result);
    }

    private static async Task<IResult> GetBillingPeriodsAsync(
        string medicalOrganizationCode,
        TargetDbType targetDb,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            request: new GetBillingPeriodsQuery(
                TargetDb: targetDb,
                MedicalOrganizationCode: medicalOrganizationCode),
            cancellationToken: cancellationToken);

        if (result.IsFailure)
        {
            return Results.BadRequest(result);
        }

        return Results.Ok(result);
    }

}