using MediatR;

using Core.Enums;

using Application.Queries.RContol.Lookups.GetBillingPeriodsQuery;
using Application.Queries.RContol.Lookups.GetMedicalOrganizationsQuery;

namespace Web.Endpoints.RControl.Lookups;

public static class RControlLookupsEndpoints
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
            new GetMedicalOrganizationsQuery(TargetDb: targetDb), 
            cancellationToken);

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
            new GetBillingPeriodsQuery(
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