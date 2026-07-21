using MediatR;

using Core.Enums;

using Application.Commands.RContol;

using Web.Dtos.Requests.RConrtol;
using Web.Registration.Endpoints;

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
        group.MapPost("/invoices-shortly", GetInvoicesShortlyAsync);
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
                Skip: (request.Pagination.PageSize * request.Pagination.CurrentPage) - request.Pagination.PageSize,
                Take: request.Pagination.PageSize,
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
        return Results.Ok();
    }

    private static async Task<IResult> GetBillingPeriodsAsync(
        string orgCode,
        string targetDbType,
        ISender sender,
        CancellationToken cancellationToken)
    {
        return Results.Ok();
    }
}
