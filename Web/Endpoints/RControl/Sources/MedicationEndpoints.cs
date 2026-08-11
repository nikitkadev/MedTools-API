using MediatR;

using Core.Common.Enums;

using Application.Queries.RContol.Medications.GetInjectionDatesQuery;
using Application.Queries.RContol.Medications.GetInjectionsQuery;

namespace Web.Endpoints.RControl.Sources;

public static class MedicationEndpoints
{
    public static void MapMedicationEndpoints(this RouteGroupBuilder builder)
    {
        var group = builder.MapGroup("/medications").WithTags("RControl Medications");

        group.MapGet("/{medicationUid:int}/injection-dates", GetInjectionDatesAsync);
        group.MapGet("/{medicationUid:int}/injections", GetInjectionsAsync);
    }

    private static async Task<IResult> GetInjectionDatesAsync(
        int medicationUid,
        TargetDbType targetDb,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            request: new GetInjectionDatesQuery(
                MedicationUid: medicationUid,
                TargetDb: targetDb),
            cancellationToken: cancellationToken);

        if (result.IsFailure)
        {
            return Results.BadRequest(result);
        }

        return Results.Ok(result);
    }

    private static async Task<IResult> GetInjectionsAsync(
        int medicationUid,
        TargetDbType targetDb,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            request: new GetInjectionsQuery(
                MedicationUid: medicationUid,
                TargetDb: targetDb),
            cancellationToken: cancellationToken);

        if (result.IsFailure)
        {
            return Results.BadRequest(result);
        }

        return Results.Ok(result);
    }

}