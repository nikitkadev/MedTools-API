using MediatR;

using Core.Common.Dtos;
using Core.Common.Results;
using Core.Interfaces.Providers.MedView.ReferenceDataProviders;

namespace Application.Queries.MedView.Filters.GetBedProfileFilterOptionsQuery;

public sealed class GetBedProfileFilterOptionsQueryHandler(
    IMedicalCareReferenceDataProvider medicalCareReferenceDataProvider) : IRequestHandler<GetBedProfileFilterOptionsQuery, Result<GetBedProfileFilterOptionsResult>>
{
    public async Task<Result<GetBedProfileFilterOptionsResult>> Handle(
        GetBedProfileFilterOptionsQuery request,
        CancellationToken cancellationToken)
    {
        var bedProfiles = await medicalCareReferenceDataProvider.GetBedProfileReferencesAsync(
            cancellationToken: cancellationToken);

        return Result<GetBedProfileFilterOptionsResult>.Success(
            new GetBedProfileFilterOptionsResult(
                FilterOptions: [.. bedProfiles.Select(x => new FilterOptionDto(
                    Value: x.BedProfileId,
                    Label: x.BedProfileName))]));
    }
}