using MediatR;

using Core.Enums;

using Application.Commands.RContol.GetPeriodsCommand;
using Application.Commands.RContol.GetOrganizationsCommand;
using Application.Commands.RContol.GetFinishedCasesCommand;
using Application.Commands.RContol.GetInvoiceSummaryCommand;
using Application.Commands.RContol.GetInvoicesShortlyCommand;

using Web.Dtos.Requests.RConrtol;
using Web.Registration.Endpoints;
using Application.Commands.RContol.GetCasesCommand;
using Application.Commands.RContol.Categories.GetPatientSmoDataCommand;

namespace Web.Endpoints.RControl;

public class RControlData : IEndpoint
{
    public void Register(IEndpointRouteBuilder endpointsBuilder)
    {
        var group = endpointsBuilder
            .MapGroup("/rcontrol")
            .WithTags("RControlData");

        group.MapGet("/med-organizations", GetMedOrganizationsAsync);
        group.MapGet("/billing-periods", GetBillingPeriodsAsync);
        group.MapGet("/invoice-summary", GetInvoiceSummaryAsync);
        group.MapPost("/invoices-shortly", GetInvoicesShortlyAsync);
        group.MapPost("/finished-cases", GetFinishedCasesAsync);
        group.MapGet("/cases", GetCasesAsync);
        group.MapGet("/categories/patient-smo", GetPatientSmoCategoryDataAsync);
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
}