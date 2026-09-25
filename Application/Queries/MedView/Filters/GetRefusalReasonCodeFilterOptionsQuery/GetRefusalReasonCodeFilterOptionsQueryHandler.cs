using MediatR;

using Core.Common.Dtos;
using Core.Common.Results;
using Core.Interfaces.Providers.MedView.ReferenceDataProviders;

namespace Application.Queries.MedView.Filters.GetRefusalReasonCodeFilterOptionsQuery;

public sealed class GetRefusalReasonCodeFilterOptionsQueryHandler(
    IPaymentReferenceDataProvider paymentReferenceDataProvider) : IRequestHandler<GetRefusalReasonCodeFilterOptionsQuery, Result<GetRefusalReasonCodeFilterOptionsResult>>
{
    public async Task<Result<GetRefusalReasonCodeFilterOptionsResult>> Handle(
        GetRefusalReasonCodeFilterOptionsQuery request,
        CancellationToken cancellationToken)
    {
        var refusalReasonCodes = await paymentReferenceDataProvider.GetRefusalReasonCodeReferencesAsync(
            cancellationToken: cancellationToken);

        return Result<GetRefusalReasonCodeFilterOptionsResult>.Success(
            new GetRefusalReasonCodeFilterOptionsResult(
                FilterOptions: [.. refusalReasonCodes.Select(x => new FilterOptionDto(
                    Value: x.Id.ToString(),
                    Label: x.Name))]));
    }
}
