using Microsoft.EntityFrameworkCore;

using MediatR;

using Core.Common.Enums;

using Application.Queries.MedView.Filters.GetInsuranceFilterOptionsQuery;
using Application.Queries.MedView.Filters.GetBedProfileFilterOptionsQuery;
using Application.Queries.MedView.Filters.GetMedicalCareProfileFilterOptionsQuery;
using Application.Queries.MedView.Filters.GetInsurancePolicyTypeFilterOptionsQuery;

using Infrastructure.Database.Factories;
using Infrastructure.Database.DbEntities.References;

namespace Web.Endpoints.MedView.Sources;

public static class FilterOptionsEndpoints
{
    public static void MapFilterOptionsEndpoints(this RouteGroupBuilder builder)
    {
        var group = builder.MapGroup("/filter-options").WithTags("Filter Options");

        group.MapGet("/available-insurance", GetAvailableInsuranceFilterOptionsAsync);
        group.MapGet("/policy-types", GetInsurancePolicyTypeFilterOptions);
        group.MapGet("/medical-care-profiles", GetMedicalCareProfileFilterOptions);
        group.MapGet("/bed-profiles", GetBedProfileFilterOptions);

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

    public async static Task<IResult> GetInsurancePolicyTypeFilterOptions(
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

    public async static Task<IResult> GetMedicalCareProfileFilterOptions(
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

    public async static Task<IResult> GetBedProfileFilterOptions(
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
}
