using MediatR;

using Core.Common.Enums;

using Application.Queries.MedView.Filters.GetInsuranceFilterOptionsQuery;

using Web.Registration.Endpoints;


namespace Web.Endpoints.MedView;

public class MedViewEndpoints : IEndpoint
{
    public void Register(IEndpointRouteBuilder endpointsBuilder)
    {
        var group = endpointsBuilder.MapGroup("/med-view").WithTags("MedView");

        group.MapGet("/test", GetTest);
        group.MapGet("/available-insurance-filter-options", GetAvailableInsuranceFilterOptionsAsync);

    }

    public async static Task<IResult> GetTest()
    {
        return Results.Ok();
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
}

public class InsuranceDto
{
    public string Code { get; set; } = string.Empty;
    public string Shortname { get; set; } = string.Empty;
}