using MediatR;

using Core.Common.Enums;

using Application.Queries.RContol.ClinicalGroups.GetClassificationCriterionsQuery;
using Application.Queries.RContol.ClinicalGroups.GetTreatmentComplexityCoefficientsQuery;

namespace Web.Endpoints.RControl.Sources;

public static class ClinicalGroupEndpoints
{
    public static void MapClinicalGroupEndpoints(this RouteGroupBuilder builder)
    {
        var group = builder.MapGroup("/clinical-groups").WithTags("RControl Clinical Groups");

        group.MapGet("/{clinicalGroupUid:int}/classification_criterions", GetClassificationCriterionsAsync);
        group.MapGet("/{clinicalGroupUid:int}/treatment-complexity-coefficients", GetTreatmentComplexityCoefficientsAsync);
    }

    private static async Task<IResult> GetClassificationCriterionsAsync(
        int clinicalGroupUid,
        TargetDbType targetDb,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            request: new GetClassificationCriterionsQuery(
                ClinicalGroupUid: clinicalGroupUid,
                TargetDb: targetDb),
            cancellationToken: cancellationToken);

        if (result.IsFailure)
        {
            return Results.BadRequest(result);
        }

        return Results.Ok(result);
    }

    private static async Task<IResult> GetTreatmentComplexityCoefficientsAsync(
        int clinicalGroupUid,
        TargetDbType targetDb,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            request: new GetTreatmentComplexityCoefficientsQuery(
                ClinicalGroupUid: clinicalGroupUid,
                TargetDb: targetDb),
            cancellationToken: cancellationToken);

        if (result.IsFailure)
        {
            return Results.BadRequest(result);
        }

        return Results.Ok(result);
    }

}