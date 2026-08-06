using MediatR;

using Core.Enums;

using Web.Endpoints.RControl.Categories.PatientInsurance;

using Application.Queries.RContol.Workspace.MedicalCases.GetMedicalCasesQuery;


namespace Web.Endpoints.RControl.Workspace;

public static class MedicalCaseEndpoints
{
    public static void MapMedicalCaseEndpoints(this RouteGroupBuilder builder)
    {
        var group = builder.MapGroup("/medical-cases").WithTags("RControl Medical Cases");

        group.MapPatientInsuranceEndpoints();

        group.MapGet("", GetMedicalCasesAsync);
    }

    private static async Task<IResult> GetMedicalCasesAsync(
        int completedCaseUid,
        TargetDbType targetDb,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            request: new GetMedicalCasesQuery(
                CompletedCaseUid: completedCaseUid,
                TargetDb: targetDb));

        if (result.IsFailure)
        {
            return Results.BadRequest(result);
        }

        return Results.Ok(result);
    }
}