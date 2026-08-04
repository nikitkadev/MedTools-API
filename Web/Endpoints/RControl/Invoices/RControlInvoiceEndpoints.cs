using MediatR;

using Core.Enums;
using Application.Queries.RContol.Invoices.GetInvoicesQuery;
using Application.Queries.RContol.Invoices.GetInvoiceSummaryQuery;

namespace Web.Endpoints.RControl.Invoices;

public static class RControlInvoiceEndpoints
{
    public static void MapInvoiceEndpoints(this RouteGroupBuilder builder)
    {
        var invoicesGroup = builder.MapGroup("/invoices").WithTags("RControl Invoices");

        invoicesGroup.MapGet("", GetInvoicesAsync);
        invoicesGroup.MapGet("/{invoiceUid:int}/summary", GetInvoiceSummaryAsync);
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

}