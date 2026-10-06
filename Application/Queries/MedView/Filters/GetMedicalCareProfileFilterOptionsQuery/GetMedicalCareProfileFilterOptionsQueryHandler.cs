using MediatR;

using Core.Common.Dtos;
using Core.Common.Results;
using Core.Interfaces.Providers.MedView.ReferenceDataProviders;

namespace Application.Queries.MedView.Filters.GetMedicalCareProfileFilterOptionsQuery;

public sealed class GetMedicalCareProfileFilterOptionsQueryHandler(
    IMedicalCareReferenceDataProvider medicalCareReferenceDataProvider) : IRequestHandler<GetMedicalCareProfileFilterOptionsQuery, Result<GetMedicalCareProfileFilterOptionsResult>>
{
    public async Task<Result<GetMedicalCareProfileFilterOptionsResult>> Handle(
        GetMedicalCareProfileFilterOptionsQuery request,
        CancellationToken cancellationToken)
    {
        var medicalCareProfiles = await medicalCareReferenceDataProvider.GetMedicalCareProfileReferencesAsync(
            cancellationToken: cancellationToken);

        return Result<GetMedicalCareProfileFilterOptionsResult>.Success(
            new GetMedicalCareProfileFilterOptionsResult(
                FilterOptions: [.. medicalCareProfiles.Select(x => new FilterOptionDto(
                    Value: x.ProfileId.ToString(),
                    Label: x.ProfileName))]));
    }
}
