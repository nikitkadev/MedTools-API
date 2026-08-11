using MediatR;

using Core.Common.Enums;

using Application.Queries.RContol.MedicalCases.GetPatientQuery;
using Application.Queries.RContol.MedicalCases.GetDefectsQuery;
using Application.Queries.RContol.MedicalCases.GetReferralsQuery;
using Application.Queries.RContol.MedicalCases.GetInsuranceQuery;
using Application.Queries.RContol.MedicalCases.GetOncologyCaseQuery;
using Application.Queries.RContol.MedicalCases.GetPrescriptionsQuery;
using Application.Queries.RContol.MedicalCases.GetClinicalGroupQuery;
using Application.Queries.RContol.MedicalCases.GetConsultationsQuery;
using Application.Queries.RContol.MedicalCases.GetMedicalSanctionsQuery;
using Application.Queries.RContol.MedicalCases.GetProvidedServicesQuery;
using Application.Queries.RContol.MedicalCases.GetMedicalCaseDetailsQuery;
using Application.Queries.RContol.MedicalCases.GetHighTechMedicalCareQuery;

namespace Web.Endpoints.RControl.Sources;

public static class MedicalCaseEndpoints
{
    public static void MapMedicalCaseEndpoints(this RouteGroupBuilder builder)
    {
        var group = builder.MapGroup("/medical-cases").WithTags("RControl Medical Cases");

        group.MapGet("/{medicalCaseUid:int}", GetMedicalCaseDetailsAsync);
        group.MapGet("/{medicalCaseUid:int}/patient", GetPatientAsync);
        group.MapGet("/{medicalCaseUid:int}/insurance", GetInsuranceAsync);
        group.MapGet("/{medicalCaseUid:int}/oncology-case", GetOncologyCaseAsync);
        group.MapGet("/{medicalCaseUid:int}/consulations", GetConsultationsAsync);
        group.MapGet("/{medicalCaseUid:int}/provided-services", GetProvidedServicesAsync);
        group.MapGet("/{medicalCaseUid:int}/clinical-group", GetClinicalGroupAsync);
        group.MapGet("/{medicalCaseUid:int}/high-tech-medical-care", GetHighTechMedicalCareAsync);
        group.MapGet("/{medicalCaseUid:int}/referrals", GetReferralsAsync);
        group.MapGet("/{medicalCaseUid:int}/prescriptions", GetPrescriptionsAsync);
        group.MapGet("/{medicalCaseUid:int}/defects", GetDefectsAsync);
        group.MapGet("/{medicalCaseUid:int}/medical-sanctions", GetMedicalSanctionsAsync);
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

    private static async Task<IResult> GetPatientAsync(
        int medicalCaseUid,
        TargetDbType targetDb,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
           request: new GetPatientQuery(
               MedicalCaseUid: medicalCaseUid,
               TargetDb: targetDb),
           cancellationToken: cancellationToken);

        if (result.IsFailure)
        {
            return Results.BadRequest(result);
        }

        return Results.Ok(result);
    }

    private static async Task<IResult> GetInsuranceAsync(
        int medicalCaseUid,
        TargetDbType targetDb,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
           request: new GetInsuranceQuery(
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
                TargetDb: targetDb),
            cancellationToken: cancellationToken);

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

    private static async Task<IResult> GetProvidedServicesAsync(
        int medicalCaseUid,
        TargetDbType targetDb,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            request: new GetProvidedServicesQuery(
                MedicalCaseUid: medicalCaseUid,
                TargetDb: targetDb),
            cancellationToken: cancellationToken);

        if (result.IsFailure)
        {
            return Results.BadRequest(result);
        }

        return Results.Ok(result);
    }

    private static async Task<IResult> GetClinicalGroupAsync(
        int medicalCaseUid,
        TargetDbType targetDb,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            request: new GetClinicalGroupQuery(
                MedicalCaseUid: medicalCaseUid,
                TargetDb: targetDb),
            cancellationToken: cancellationToken);

        if (result.IsFailure)
        {
            return Results.BadRequest(result);
        }

        return Results.Ok(result);
    }

    private static async Task<IResult> GetHighTechMedicalCareAsync(
        int medicalCaseUid,
        TargetDbType targetDb,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            request: new GetHighTechMedicalCareQuery(
                MedicalCaseUid: medicalCaseUid,
                TargetDb: targetDb),
            cancellationToken: cancellationToken);

        if (result.IsFailure)
        {
            return Results.BadRequest(result);
        }

        return Results.Ok(result);
    }

    private static async Task<IResult> GetReferralsAsync(
        int medicalCaseUid,
        TargetDbType targetDb,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            request: new GetReferralsQuery(
                MedicalCaseUid: medicalCaseUid,
                TargetDb: targetDb),
            cancellationToken: cancellationToken);

        if (result.IsFailure)
        {
            return Results.BadRequest(result);
        }

        return Results.Ok(result);
    }

    private static async Task<IResult> GetPrescriptionsAsync(
        int medicalCaseUid,
        TargetDbType targetDb,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            request: new GetPrescriptionsQuery(
                MedicalCaseUid: medicalCaseUid,
                TargetDb: targetDb),
            cancellationToken: cancellationToken);

        if (result.IsFailure)
        {
            return Results.BadRequest(result);
        }

        return Results.Ok(result);
    }

    private static async Task<IResult> GetDefectsAsync(
        int medicalCaseUid,
        TargetDbType targetDb,
        int page,
        int pageSize,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            request: new GetDefectsQuery(
                MedicalCaseUid: medicalCaseUid,
                TargetDb: targetDb,
                Page: page,
                PageSize: pageSize),
            cancellationToken: cancellationToken);

        if (result.IsFailure)
        {
            return Results.BadRequest(result);
        }

        return Results.Ok(result);
    }

    private static async Task<IResult> GetMedicalSanctionsAsync(
        int medicalCaseUid,
        TargetDbType targetDb,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            request: new GetMedicalSanctionsQuery(
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