using MediatR;

using Core.Enums;

using Application.Queries.RContol.Workspace.Invoices.GetInvoicesQuery;
using Application.Queries.RContol.Workspace.Invoices.GetInvoiceSummaryQuery;
using Application.Queries.RContol.Workspace.CompletedCases.GetCompletedCasesQuery;

namespace Web.Endpoints.RControl.Invoices;

public static class InvoiceEndpoints
{
    public static void MapInvoiceEndpoints(this RouteGroupBuilder builder)
    {
        var group = builder.MapGroup("/invoices").WithTags("RControl Invoices");

        group.MapGet("", GetInvoicesAsync);
        group.MapGet("/{invoiceUid:int}/summary", GetInvoiceSummaryAsync);
        group.MapGet("/{invoiceUid:int}/completed-cases", GetCompletedCasesAsync);
    }

    private static async Task<IResult> GetInvoicesAsync(
        string medicalOrganizationCode,
        int year,
        int month,
        int page,
        int pageSize,
        TargetDbType targetDb,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            request: new GetInvoicesQuery(
                MedicalOrganizationCode: medicalOrganizationCode,
                BillingYear: year,
                BillingMonth: month,
                Page: page,
                PageSize: pageSize,
                TargetDb: targetDb),
            cancellationToken: cancellationToken);

        if (result.IsFailure)
        {
            return Results.BadRequest(result);
        }

        return Results.Ok(result);
        
    }   

    private static async Task<IResult> GetInvoiceSummaryAsync(
        int invoiceUid,
        TargetDbType targetDb,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            request: new GetInvoiceSummaryQuery(
                InvoiceUid: invoiceUid,
                TargetDb: targetDb),
            cancellationToken: cancellationToken);

        if (result.IsFailure)
        {
            return Results.BadRequest(result);
        }

        return Results.Ok(result);
    }

    private static async Task<IResult> GetCompletedCasesAsync(
        int invoiceUid,
        int page,
        int pageSize,
        TargetDbType targetDb,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            request: new GetCompletedCasesQuery(
                InvoiceUid: invoiceUid,
                Page: page,
                PageSize: pageSize,
                TargetDb: targetDb),
            cancellationToken: cancellationToken);

        if (result.IsFailure)
        {
            return Results.BadRequest(result);
        }

        return Results.Ok(result);
    }

}