using MediatR;

using Core.Common.Dtos;
using Core.Common.Results;
using Core.Interfaces.Providers.MedView.ReferenceDataProviders;

namespace Application.Queries.MedView.Filters.GetReferralReasonFilterOptionsQuery;

public sealed class GetReferralReasonFilterOptionsQueryHandler(
    IMedicalCareReferenceDataProvider medicalCareReferenceDataProvider) : IRequestHandler<GetReferralReasonFilterOptionsQuery, Result<GetReferralReasonFilterOptionsResult>>
{
    public async Task<Result<GetReferralReasonFilterOptionsResult>> Handle(
        GetReferralReasonFilterOptionsQuery request,
        CancellationToken cancellationToken)
    {
        var referralReasons = await medicalCareReferenceDataProvider.GetReferralReasonReferencesAsync(
            cancellationToken: cancellationToken);

        return Result<GetReferralReasonFilterOptionsResult>.Success(
            new GetReferralReasonFilterOptionsResult(
                FilterOptions: [.. referralReasons.Select(x => new FilterOptionDto(
                    Value: x.Id.ToString(),
                    Label: x.Name))]));
    }
}