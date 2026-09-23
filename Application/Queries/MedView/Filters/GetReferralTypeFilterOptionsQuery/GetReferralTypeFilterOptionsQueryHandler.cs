using MediatR;

using Core.Common.Dtos;
using Core.Common.Results;
using Core.Interfaces.Providers.MedView.ReferenceDataProviders;

namespace Application.Queries.MedView.Filters.GetReferralTypeFilterOptionsQuery;

public sealed class GetReferralTypeFilterOptionsQueryHandler(
    IMedicalServiceReferenceDataProvider medicalServiceReferenceDataProvider) : IRequestHandler<GetReferralTypeFilterOptionsQuery, Result<GetReferralTypeFilterOptionsResult>>
{
    public async Task<Result<GetReferralTypeFilterOptionsResult>> Handle(
        GetReferralTypeFilterOptionsQuery request,
        CancellationToken cancellationToken)
    {
        var referralTypes = await medicalServiceReferenceDataProvider.GetReferralTypeReferencesAsync(
            cancellationToken: cancellationToken);

        return Result<GetReferralTypeFilterOptionsResult>.Success(
            new GetReferralTypeFilterOptionsResult(
                Options: [.. referralTypes.Select(x => new FilterOptionDto(
                    Key: x.Id.ToString(),
                    Value: x.Name))]));
    }
}
