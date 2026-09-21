using Microsoft.EntityFrameworkCore;

using MediatR;

using Core.Common.Enums;

using Application.Queries.MedView.Filters.GetCareFormFilterOptionsQuery;
using Application.Queries.MedView.Filters.GetInsuranceFilterOptionsQuery;
using Application.Queries.MedView.Filters.GetBedProfileFilterOptionsQuery;
using Application.Queries.MedView.Filters.GetVisitPlaceFilterOptionsQuery;
using Application.Queries.MedView.Filters.GetVisitPurposeFilterOptionsQuery;
using Application.Queries.MedView.Filters.GetDiseaseStageFilterOptionsQuery;
using Application.Queries.MedView.Filters.GetPaymentMethodFilterOptionsQuery;
using Application.Queries.MedView.Filters.GetCareConditionFilterOptionsQuery;
using Application.Queries.MedView.Filters.GetDiseaseOutcomeFilterOptionsQuery;
using Application.Queries.MedView.Filters.GetReferralReasonFilterOptionsQuery;
using Application.Queries.MedView.Filters.GetMedicalCareTypeFilterOptionsQuery;
using Application.Queries.MedView.Filters.GetScreeningResultFilterOptionsQuery;
using Application.Queries.MedView.Filters.GetDiseaseCharacterFilterOptionsQuery;
using Application.Queries.MedView.Filters.GetMedicalCareProfileFilterOptionsQuery;
using Application.Queries.MedView.Filters.GetInsurancePolicyTypeFilterOptionsQuery;
using Application.Queries.MedView.Filters.GetMedicalOrganizationFilterOptionsQuery;
using Application.Queries.MedView.Filters.GetPhysicianSpecialityFilterOptionsQuery;
using Application.Queries.MedView.Filters.GetHospitalizationOutcomeFilterOptionsQuery;

using Infrastructure.Database.Factories;
using Infrastructure.Database.DbEntities.References;


namespace Web.Endpoints.MedView.Sources;

public static class FilterOptionsEndpoints
{
    public static void MapFilterOptionsEndpoints(this RouteGroupBuilder builder)
    {
        var group = builder.MapGroup("/filter-options").WithTags("Filter Options");

        group.MapGet("/available-insurance", GetAvailableInsuranceFilterOptionsAsync);
        group.MapGet("/policy-types", GetInsurancePolicyTypeFilterOptionsAsync);
        group.MapGet("/medical-care-profiles", GetMedicalCareProfileFilterOptionsAsync);
        group.MapGet("/bed-profiles", GetBedProfileFilterOptionsAsync);
        group.MapGet("/visit-places", GetVisitPlaceFilterOptionsAsync);
        group.MapGet("/visit-purposes", GetVisitPurposesFilterOptionsAsync);
        group.MapGet("/disease-characters", GetDiseaseCharacterFilterOptionsAsync);
        group.MapGet("/physician-specialities", GetPhysicianSpecialityFilterOptionsAsync);
        group.MapGet("/medical-organizations", GetMedicalOrganizationFilterOptionsAsync);
        group.MapGet("/care-conditions", GetCareConditionFilterOptionsAsync);
        group.MapGet("/medical-care-types", GetMedicalCareTypeFilterOptionsAsync);
        group.MapGet("/medical-care-forms", GetMedicalCareFormFilterOptionsAsync);
        group.MapGet("/disease-outcomes", GetDiseaseOutcomeFilterOptionsAsync);
        group.MapGet("/screening-results", GetScreeningResultFilterOptionsAsync);
        group.MapGet("/hospitalization-outcomes", GetHospitalizationOutcomeFilterOptionsAsync);
        group.MapGet("/payment-methods", GetPaymentMethodFilterOptionsAsync);
        group.MapGet("/referral-reasons", GetReferralReasonsFilterOptionsAsync);
        group.MapGet("/disease-stages", GetDiseaseStageFilterOptionsAsync);

        group.MapGet("/test", TestThisShitAsync);
    }

    public async static Task<IResult> TestThisShitAsync(DbContextFactory dbContextFactory)
    {
        var dbContext = dbContextFactory.CreateDbContext(TargetDbType.MEDSPR18);
        var result = await dbContext
            .Set<DivisionDbEntity>()
            .ToListAsync();

        return Results.Ok(result);
    }


    public async static Task<IResult> GetAvailableInsuranceFilterOptionsAsync(
        TargetDbType targetDb,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetInsuranceFilterOptionsQuery(targetDb), cancellationToken);

        if (!result.IsSuccess)
        {
            return Results.BadRequest();
        }

        return Results.Ok(result);
    }

    public async static Task<IResult> GetInsurancePolicyTypeFilterOptionsAsync(
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            request: new GetInsurancePolicyTypeFilterOptionsQuery(),
            cancellationToken: cancellationToken);

        if (!result.IsSuccess)
        {
            return Results.BadRequest();
        }

        return Results.Ok(result);
    }

    public async static Task<IResult> GetMedicalCareProfileFilterOptionsAsync(
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            request: new GetMedicalCareProfileFilterOptionsQuery(),
            cancellationToken: cancellationToken);

        if (!result.IsSuccess)
        {
            return Results.BadRequest();
        }

        return Results.Ok(result);
    }

    public async static Task<IResult> GetBedProfileFilterOptionsAsync(
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            request: new GetBedProfileFilterOptionsQuery(),
            cancellationToken: cancellationToken);

        if (!result.IsSuccess)
        {
            return Results.BadRequest();
        }

        return Results.Ok(result);
    }

    public async static Task<IResult> GetVisitPlaceFilterOptionsAsync(
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            request: new GetVisitPlaceFilterOptionsQuery(),
            cancellationToken: cancellationToken);

        if (!result.IsSuccess)
        {
            return Results.BadRequest();
        }

        return Results.Ok(result);
    }

    public async static Task<IResult> GetVisitPurposesFilterOptionsAsync(
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            request: new GetVisitPurposeFilterOptionsQuery(),
            cancellationToken: cancellationToken);

        if (!result.IsSuccess)
        {
            return Results.BadRequest();
        }

        return Results.Ok(result);
    }

    public async static Task<IResult> GetDiseaseCharacterFilterOptionsAsync(
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            request: new GetDiseaseCharacterFilterOptionsQuery(),
            cancellationToken: cancellationToken);

        if (!result.IsSuccess)
        {
            return Results.BadRequest();
        }

        return Results.Ok(result);
    }

    public async static Task<IResult> GetPhysicianSpecialityFilterOptionsAsync(
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            request: new GetPhysicianSpecialityFilterOptionsQuery(),
            cancellationToken: cancellationToken);

        if (!result.IsSuccess)
        {
            return Results.BadRequest();
        }

        return Results.Ok(result);
    }

    public async static Task<IResult> GetMedicalOrganizationFilterOptionsAsync(
        TargetDbType targetDb,
        MedicalOrgsKeysFrom medicalOrgsKeysFrom,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            request: new GetMedicalOrganizationFilterOptionsQuery(
                TargetDb: targetDb,
                MedicalOrgsKeysFrom: medicalOrgsKeysFrom),
            cancellationToken: cancellationToken);

        if (!result.IsSuccess)
        {
            return Results.BadRequest();
        }

        return Results.Ok(result);
    }

    public async static Task<IResult> GetCareConditionFilterOptionsAsync(
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            request: new GetCareConditionFilterOptionsQuery(),
            cancellationToken: cancellationToken);

        if (!result.IsSuccess)
        {
            return Results.BadRequest();
        }

        return Results.Ok(result);
    }

    public async static Task<IResult> GetMedicalCareTypeFilterOptionsAsync(
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            request: new GetMedicalCareTypeFilterOptionsQuery(),
            cancellationToken: cancellationToken);

        if (!result.IsSuccess)
        {
            return Results.BadRequest();
        }

        return Results.Ok(result);
    }

    public async static Task<IResult> GetMedicalCareFormFilterOptionsAsync(
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            request: new GetCareFormFilterOptionsQuery(),
            cancellationToken: cancellationToken);

        if (!result.IsSuccess)
        {
            return Results.BadRequest();
        }

        return Results.Ok(result);
    }

    public async static Task<IResult> GetDiseaseOutcomeFilterOptionsAsync(
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            request: new GetDiseaseOutcomeFilterOptionsQuery(),
            cancellationToken: cancellationToken);

        if (!result.IsSuccess)
        {
            return Results.BadRequest();
        }

        return Results.Ok(result);
    }

    public async static Task<IResult> GetScreeningResultFilterOptionsAsync(
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            request: new GetScreeningResultFilterOptionsQuery(),
            cancellationToken: cancellationToken);

        if (!result.IsSuccess)
        {
            return Results.BadRequest();
        }

        return Results.Ok(result);
    }

    public async static Task<IResult> GetHospitalizationOutcomeFilterOptionsAsync(
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            request: new GetHospitalizationOutcomeFilterOptionsQuery(),
            cancellationToken: cancellationToken);

        if (!result.IsSuccess)
        {
            return Results.BadRequest();
        }

        return Results.Ok(result);
    }

    public async static Task<IResult> GetPaymentMethodFilterOptionsAsync(
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            request: new GetPaymentMethodFilterOptionsQuery(),
            cancellationToken: cancellationToken);

        if (!result.IsSuccess)
        {
            return Results.BadRequest();
        }

        return Results.Ok(result);
    }

    public async static Task<IResult> GetReferralReasonsFilterOptionsAsync(
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            request: new GetReferralReasonFilterOptionsQuery(),
            cancellationToken: cancellationToken);

        if (!result.IsSuccess)
        {
            return Results.BadRequest();
        }

        return Results.Ok(result);
    }

    public async static Task<IResult> GetDiseaseStageFilterOptionsAsync(
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            request: new GetDiseaseStageFilterOptionsQuery(),
            cancellationToken: cancellationToken);

        if (!result.IsSuccess)
        {
            return Results.BadRequest();
        }

        return Results.Ok(result);
    }

}