using MediatR;

using Core.Enums;

using Application.Queries.RContol.Categories.Oncology.GetInjectionsCommand;
using Application.Queries.RContol.Categories.NazNapr.GetNazNaprDataCommand;
using Application.Queries.RContol.Categories.Oncology.GetMedicamentsCommand;
using Application.Queries.RContol.Categories.KsgVmp.GetKsgVmpCardsDataCommand;
using Application.Queries.RContol.Categories.DefectsSanks.GetSanksDataCommand;
using Application.Queries.RContol.Categories.KsgVmp.GetKsgVmpTablesDataCommand;
using Application.Queries.RContol.Categories.ProvidedServices.GetMedDevsCommand;
using Application.Queries.RContol.Categories.DefectsSanks.GetDefectsDataCommand;
using Application.Queries.RContol.Categories.ProvidedServices.GetProvidedServicesCommand;

using Web.Registration.Endpoints;
using Web.Endpoints.RControl.Lookups;
using Web.Endpoints.RControl.CompletedCases;
using Web.Endpoints.RControl.MedicalCases;
using Web.Endpoints.RControl.Invoices;
using Web.Endpoints.RControl.OncologyCases;

namespace Web.Endpoints.RControl;

public class RControlEndpoints : IEndpoint
{
    public void Register(IEndpointRouteBuilder endpointsBuilder)
    {
        var group = endpointsBuilder.MapGroup("/rcontrol").WithTags("RControlData");

        group.MapLookups();
        group.MapInvoiceEndpoints();
        group.MapMedicalCaseEndpoints();
        group.MapOncologyCaseEndpoints();
        group.MapCompletedCaseEndpoints();

        

        group.MapGet("/categories/oncology/medicaments", GetOncologyCategoryMedicamentsAsync);
        group.MapGet("/categories/oncology/injections", GetOncologyCategoryInjectionsAsync);
        group.MapGet("/categories/provided-services/services", GetProvidedServicesAsync);
        group.MapGet("/categories/provided-services/med-devs", GetMedDevsAsync);
        group.MapGet("/categories/ksg-vmp/cards-data", GetKsgVmpCardsData);
        group.MapGet("/categories/ksg-vmp/tables-data", GetKsgVmpTablesData);
        group.MapGet("/categories/naz-napr", GetNazNaprCategoryData);
        group.MapGet("/categories/defects-sanks/sanks", GetSanksDataAsync);
        group.MapGet("/categories/defects-sanks/defects", GetDefectsDataAsync);
        
    }


    private static async Task<IResult> GetOncologyCategoryMedicamentsAsync(
        int oncServiceUid,
        string targetDb,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            request: new GetMedicamentsCommand(
                OncServiceUid: oncServiceUid,
                TargetDb: Enum.Parse<TargetDbType>(targetDb)),
            cancellationToken: cancellationToken);

        if (result.IsFailure)
        {
            return Results.BadRequest(result);
        }

        return Results.Ok(result);

    }

    private static async Task<IResult> GetOncologyCategoryInjectionsAsync(
        int medicamentUid,
        string targetDb,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            request: new GetInjectionsCommand(
                MedicamentUid: medicamentUid,
                TargetDb: Enum.Parse<TargetDbType>(targetDb)),
            cancellationToken: cancellationToken);

        if (result.IsFailure)
        {
            return Results.BadRequest(result);
        }

        return Results.Ok(result);
    }
    
    private static async Task<IResult> GetProvidedServicesAsync(
        int sluchUid,
        string targetDb,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            request: new GetProvidedServicesCommand(
                SluchUid: sluchUid,
                TargetDb: Enum.Parse<TargetDbType>(targetDb)),
            cancellationToken: cancellationToken);

        if (result.IsFailure)
        {
            return Results.BadRequest(result);
        }

        return Results.Ok(result);
    }

    private static async Task<IResult> GetMedDevsAsync(
        int providedServiceUid,
        string targetDb,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            request: new GetMedDevsCommand(
                ProvidedServiceUid: providedServiceUid,
                TargetDb: Enum.Parse<TargetDbType>(targetDb)),
            cancellationToken: cancellationToken);

        if (result.IsFailure)
        {
            return Results.BadRequest(result);
        }

        return Results.Ok(result);
    }

    private static async Task<IResult> GetKsgVmpCardsData(
        int sluchUid,
        string targetDb,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            request: new GetKsgVmpCardsDataCommand(
                SluchUid: sluchUid,
                TargetDb: Enum.Parse<TargetDbType>(targetDb)),
            cancellationToken: cancellationToken);

        if (result.IsFailure)
        {
            return Results.BadRequest(result);
        }

        return Results.Ok(result);
    }

    private static async Task<IResult> GetKsgVmpTablesData(
        int ksgKpgUid,
        string targetDb,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            request: new GetKsgVmpTablesDataCommand(
                KsgKpgUid: ksgKpgUid,
                TargetDb: Enum.Parse<TargetDbType>(targetDb)),
            cancellationToken: cancellationToken);

        if (result.IsFailure)
        {
            return Results.BadRequest(result);
        }

        return Results.Ok(result);
    }

    private static async Task<IResult> GetNazNaprCategoryData(
        int sluchUid,
        string targetDb,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
           request: new GetNazNaprDataCommand(
               SluchUid: sluchUid,
               TargetDb: Enum.Parse<TargetDbType>(targetDb)),
           cancellationToken: cancellationToken);

        if (result.IsFailure)
        {
            return Results.BadRequest(result);
        }

        return Results.Ok(result);
    }

    private static async Task<IResult> GetSanksDataAsync(
        int sluchUid,
        string targetDb,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
           request: new GetSanksDataCommand(
               SluchUid: sluchUid,
               TargetDb: Enum.Parse<TargetDbType>(targetDb)),
           cancellationToken: cancellationToken);

        if (result.IsFailure)
        {
            return Results.BadRequest(result);
        }

        return Results.Ok(result);
    }

    private static async Task<IResult> GetDefectsDataAsync(
        int sluchUid,
        string targetDb,
        int page,
        int pageSize,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
           request: new GetDefectsDataCommand(
               SluchUid: sluchUid,
               TargetDb: Enum.Parse<TargetDbType>(targetDb),
               Page: page,
               PageSize: pageSize),
           cancellationToken: cancellationToken);

        if (result.IsFailure)
        {
            return Results.BadRequest(result);
        }

        return Results.Ok(result);
    }
}