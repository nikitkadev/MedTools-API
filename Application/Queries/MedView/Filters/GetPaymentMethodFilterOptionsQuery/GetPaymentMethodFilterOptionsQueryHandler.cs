using MediatR;

using Core.Common.Dtos;
using Core.Common.Results;
using Core.Interfaces.Providers.MedView.ReferenceDataProviders;

namespace Application.Queries.MedView.Filters.GetPaymentMethodFilterOptionsQuery;

public sealed class GetPaymentMethodFilterOptionsQueryHandler(
    IPaymentReferenceDataProvider paymentReferenceDataProvider) : IRequestHandler<GetPaymentMethodFilterOptionsQuery, Result<GetPaymentMethodFilterOptionsResult>>
{
    public async Task<Result<GetPaymentMethodFilterOptionsResult>> Handle(
        GetPaymentMethodFilterOptionsQuery request,
        CancellationToken cancellationToken)
    {
        var paymentMethods = await paymentReferenceDataProvider.GetPaymentMethodReferencesAsync(
            cancellationToken: cancellationToken);

        return Result<GetPaymentMethodFilterOptionsResult>.Success(
            new GetPaymentMethodFilterOptionsResult(
                FilterOptions: [.. paymentMethods.Select(x => new FilterOptionDto(
                    Value: x.Id.ToString(),
                    Label: x.Name))]));
    }
}