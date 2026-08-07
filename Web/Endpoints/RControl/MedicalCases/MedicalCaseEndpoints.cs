using MediatR;

using Core.Enums;

using Application.Queries.RContol.Oncology.GetOncologyCaseQuery;
using Application.Queries.RContol.Workspace.MedicalCases.GetMedicalCaseDetailsQuery;
using Application.Queries.RContol.Categories.PatientInsurance.GetPatientInsuranceQuery;
using Application.Queries.RContol.MedicalCases.GetConsulationsQuery;


namespace Web.Endpoints.RControl.MedicalCases;

public static class MedicalCaseEndpoints
{
    public static void MapMedicalCaseEndpoints(this RouteGroupBuilder builder)
    {
        var group = builder.MapGroup("/medical-cases").WithTags("RControl Medical Cases");

        group.MapGet("/{medicalCaseUid:int}", GetMedicalCaseDetailsAsync);
        group.MapGet("/{medicalCaseUid:int}/patient-insurance", GetPaientInsuranceAsync);
        group.MapGet("/{medicalCaseUid:int}/oncology-case", GetOncologyCaseAsync);
        group.MapGet("/{medicalCaseUid:int}/consulations", GetConsultationsAsync);

    }

    private static async Task<IResult> GetMedicalCaseDetailsAsync(
        int medicalCaseUid,
        TargetDbType targetDb,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            request: new GetMedicalCaseDetailsQuery(
                MedicalCaseUid: medicalCaseUid,
                TargetDb: targetDb),
            cancellationToken: cancellationToken);

        if (result.IsFailure)
        {
            return Results.BadRequest(result);
        }

        return Results.Ok(result);
    }

    private static async Task<IResult> GetPaientInsuranceAsync(
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

    private static async Task<IResult> GetOncologyCaseAsync(
        int medicalCaseUid,
        TargetDbType targetDb,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            request: new GetOncologyCaseQuery(
                MedicalCaseUid: medicalCaseUid,
                TargetDb: targetDb));

        if (result.IsFailure)
        {
            return Results.BadRequest(result);
        }

        return Results.Ok(result);
    }

    private static async Task<IResult> GetConsultationsAsync(
        int medicalCaseUid,
        TargetDbType targetDb,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            request: new GetConsultationsQuery(
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