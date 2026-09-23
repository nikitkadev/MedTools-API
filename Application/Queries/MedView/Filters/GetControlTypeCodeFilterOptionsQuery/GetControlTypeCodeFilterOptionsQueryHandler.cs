using MediatR;

using Core.Common.Dtos;
using Core.Common.Results;
using Core.Interfaces.Providers.MedView.ReferenceDataProviders;

namespace Application.Queries.MedView.Filters.GetControlTypeCodeFilterOptionsQuery;

public sealed class GetControlTypeCodeFilterOptionsQueryHandler(
    IPaymentReferenceDataProvider paymentReferenceDataProvider) : IRequestHandler<GetControlTypeCodeFilterOptionsQuery, Result<GetControlTypeCodeFilterOptionsResult>>
{
    public async Task<Result<GetControlTypeCodeFilterOptionsResult>> Handle(
        GetControlTypeCodeFilterOptionsQuery request,
        CancellationToken cancellationToken)
    {
        var controlTypeCodes = await paymentReferenceDataProvider.GetControlTypeCodeReferencesAsync(
            cancellationToken: cancellationToken);

        return Result<GetControlTypeCodeFilterOptionsResult>.Success(
            new GetControlTypeCodeFilterOptionsResult(
                Options: [.. controlTypeCodes.Select(x => new FilterOptionDto(
                    Key: x.Id,
                    Value: x.Name))]));
    }
}
