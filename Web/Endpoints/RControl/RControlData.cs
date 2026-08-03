using MediatR;

using Core.Enums;

using Application.Commands.RContol.Filters.GetPeriodsCommand;
using Application.Commands.RContol.MainField.GetCasesCommand;
using Application.Commands.RContol.Categories.GetCasesDataCommand;
using Application.Commands.RContol.Filters.GetOrganizationsCommand;
using Application.Commands.RContol.MainField.GetFinishedCasesCommand;
using Application.Commands.RContol.MainField.GetInvoiceSummaryCommand;
using Application.Commands.RContol.Categories.GetPatientSmoDataCommand;
using Application.Commands.RContol.MainField.GetInvoicesShortlyCommand;
using Application.Commands.RContol.Categories.Oncology.GetOncSluchCommand;
using Application.Commands.RContol.Categories.Oncology.GetInjectionsCommand;
using Application.Commands.RContol.Categories.NazNapr.GetNazNaprDataCommand;
using Application.Commands.RContol.Categories.Oncology.GetMedicamentsCommand;
using Application.Commands.RContol.Categories.Oncology.GetConsultationCommand;
using Application.Commands.RContol.Categories.KsgVmp.GetKsgVmpCardsDataCommand;
using Application.Commands.RContol.Categories.DefectsSanks.GetSanksDataCommand;
using Application.Commands.RContol.Categories.KsgVmp.GetKsgVmpTablesDataCommand;
using Application.Commands.RContol.Categories.ProvidedServices.GetMedDevsCommand;
using Application.Commands.RContol.Categories.DefectsSanks.GetDefectsDataCommand;
using Application.Commands.RContol.Categories.Oncology.GetDetailedOncSluchCommand;
using Application.Commands.RContol.Categories.ProvidedServices.GetProvidedServicesCommand;

using Web.Dtos.Requests.RConrtol;
using Web.Registration.Endpoints;


namespace Web.Endpoints.RControl;

public class RControlData : IEndpoint
{
    public void Register(IEndpointRouteBuilder endpointsBuilder)
    {
        var group = endpointsBuilder.MapGroup("/rcontrol").WithTags("RControlData");

        group.MapGet("/med-organizations", GetMedOrganizationsAsync);
        group.MapGet("/billing-periods", GetBillingPeriodsAsync);
        group.MapGet("/invoice-summary", GetInvoiceSummaryAsync);
        group.MapPost("/invoices-shortly", GetInvoicesShortlyAsync);
        group.MapPost("/finished-cases", GetFinishedCasesAsync);
        group.MapGet("/cases", GetCasesAsync);
        group.MapGet("/categories/patient-smo", GetPatientSmoCategoryDataAsync);
        group.MapGet("/categories/cases", GetCasesCategoryDataAsync);
        group.MapGet("/categories/oncology/onc-sluch", GetOncologyCategoryOnkCaseAsync);
        group.MapGet("/categories/oncology/consultations", GetOncologyCategoryConsultationsAsync);
        group.MapGet("/categories/oncology/onc-sluch-detailed", GetOncologyCategoryOncSluchDetailed);
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

    private static async Task<IResult> GetInvoicesShortlyAsync(
        GetInvoicesShortlyRequest request,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            request: new GetInvoicesShortlyCommand(
                OrgCode: request.OrgCode,
                Year: request.Year,
                Month: request.Month,
                Page: request.Pagination.CurrentPage,
                PageSize: request.Pagination.PageSize,
                TargetDb: Enum.Parse<TargetDbType>(request.DbType.DbType),
                SearchString: request.Search.GlobalSearchString ?? string.Empty), 
            cancellationToken: cancellationToken);

        if (result.IsFailure)
        {
            return Results.BadRequest(result);
        }

        return Results.Ok(result);
    }

    private static async Task<IResult> GetMedOrganizationsAsync(
        string targetDbType,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            request: new GetOrganizationsCommand(TargetDb: Enum.Parse<TargetDbType>(targetDbType)),
            cancellationToken: cancellationToken);

        if (result.IsFailure)
        {
            return Results.BadRequest(result);
        }

        return Results.Ok(result);
    }

    private static async Task<IResult> GetBillingPeriodsAsync(
        string targetDbType,
        string orgCode,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            new GetPeriodsCommand(
                TargetDbType: Enum.Parse<TargetDbType>(targetDbType),
                OrgCode: orgCode),
            cancellationToken: cancellationToken);

        if (result.IsFailure)
        {
            return Results.BadRequest(result);
        }

        return Results.Ok(result);
    }

    private static async Task<IResult> GetInvoiceSummaryAsync(
        int schetUid,
        string targetDb,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            new GetInvoiceSummaryCommand(
                TargetDb: Enum.Parse<TargetDbType>(targetDb),
                SchetUid: schetUid),
            cancellationToken: cancellationToken);

        if (result.IsFailure)
        {
            return Results.BadRequest(result);
        }

        return Results.Ok(result);
    }

    private static async Task<IResult> GetFinishedCasesAsync(
        GetFinishedCasesRequest request,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            request: new GetFinishedCasesCommand(
                SchetUid: request.SchetUid,
                Page: request.Pagination.CurrentPage,
                PageSize: request.Pagination.PageSize,
                TargetDb: Enum.Parse<TargetDbType>(request.DbType.DbType),
                SearchString: request.Search.GlobalSearchString ?? string.Empty),
            cancellationToken: cancellationToken);

        if (result.IsFailure)
        {
            return Results.BadRequest(result);
        }

        return Results.Ok(result);
    }

    private static async Task<IResult> GetCasesAsync(
        int zSlUid,
        string targetDb,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            request: new GetCasesCommand(
                ZSlUid: zSlUid,
                TargetDb: Enum.Parse<TargetDbType>(targetDb)),
            cancellationToken: cancellationToken);

        if (result.IsFailure)
        {
            return Results.BadRequest(result);
        }

        return Results.Ok(result);
    }

    private static async Task<IResult> GetPatientSmoCategoryDataAsync(
        int sluchUid,
        string targetDb,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            request: new GetPatientSmoDataCommand(
                SluchUid: sluchUid,
                TargetDb: Enum.Parse<TargetDbType>(targetDb)),
            cancellationToken: cancellationToken);

        if (result.IsFailure)
        {
            return Results.BadRequest(result);
        }

        return Results.Ok(result);
    }

    private static async Task<IResult> GetCasesCategoryDataAsync(
        int sluchUid,
        string targetDb,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            request: new GetCasesDataCommand(
                SluchUid: sluchUid,
                TargetDb: Enum.Parse<TargetDbType>(targetDb)),
            cancellationToken: cancellationToken);

        if (result.IsFailure)
        {
            return Results.BadRequest(result);
        }

        return Results.Ok(result);
    }

    private static async Task<IResult> GetOncologyCategoryOnkCaseAsync(
        int sluchUid,
        string targetDb,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            request: new GetOncSluchCommand(
                SluchUid: sluchUid,
                TargetDb: Enum.Parse<TargetDbType>(targetDb)),
            cancellationToken: cancellationToken);

        if (result.IsFailure)
        {
            return Results.BadRequest(result);
        }

        return Results.Ok(result);
    }

    private static async Task<IResult> GetOncologyCategoryConsultationsAsync(
        int sluchUid,
        string targetDb,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            request: new GetConsultationCommand(
                SluchUid: sluchUid,
                TargetDb: Enum.Parse<TargetDbType>(targetDb)),
            cancellationToken: cancellationToken);

        if (result.IsFailure)
        {
            return Results.BadRequest(result);
        }

        return Results.Ok(result);
    }

    private static async Task<IResult> GetOncologyCategoryOncSluchDetailed(
        int oncSluchUid,
        string targetDb,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            request: new GetDetailedOncSluchCommand(
                OncSluchUid: oncSluchUid,
                TargetDb: Enum.Parse<TargetDbType>(targetDb)),
            cancellationToken: cancellationToken);

        if (result.IsFailure)
        {
            return Results.BadRequest(result);
        }

        return Results.Ok(result);
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