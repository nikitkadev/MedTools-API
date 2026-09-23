using MediatR;

using Core.Common.Dtos;
using Core.Common.Results;
using Core.Interfaces.Providers.MedView.ReferenceDataProviders;

namespace Application.Queries.MedView.Filters.GetComplexityCoefficientOptionsQuery;

public sealed class GetComplexityCoefficientOptionsQueryHandler(
    IPaymentReferenceDataProvider paymentReferenceDataProvider) : IRequestHandler<GetComplexityCoefficientOptionsQuery, Result<GetComplexityCoefficientOptionsResult>>
{
    public async Task<Result<GetComplexityCoefficientOptionsResult>> Handle(
        GetComplexityCoefficientOptionsQuery request,
        CancellationToken cancellationToken)
    {
        var complexityCoefficients = await paymentReferenceDataProvider.GetComplexityCoefficientReferencesAsync(
            cancellationToken: cancellationToken);

        return Result<GetComplexityCoefficientOptionsResult>.Success(
            new GetComplexityCoefficientOptionsResult(
                Options: [.. complexityCoefficients.Select(x => new FilterOptionDto(
                    Key: x.Id,
                    Value: x.Name))]));
    }
}
