using MediatR;

using Core.Enums;

using Application.Queries.RContol.Categories.PatientInsurance.GetPatientInsuranceQuery;

namespace Web.Endpoints.RControl.Categories.PatientInsurance;

public static class RControlPatientInsuranceCategoryEndpoints
{
    public static void MapPatientInsuranceCategoryEndpoints(this RouteGroupBuilder builder)
    {
        var group = builder.MapGroup("/{medicalCaseUid:int}/patient-insurance").WithTags("RControl PatientInsurance Category");

        group.MapGet("", GetPaientInsuranceAsync);
    }

    public static async Task<IResult> GetPaientInsuranceAsync(
        int medicalCaseUid,
        TargetDbType targetDb,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            request: new GetPatientInsuranceQuery(
                MedicalCaseUid: medicalCaseUid,
                TargetDb: targetDb),
            cancellationToken: cancellationToken);

        if (result.IsFailure)
        {
            return Results.BadRequest(result);
        }

        return Results.Ok(result);
    }
}
