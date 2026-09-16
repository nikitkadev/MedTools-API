using MediatR;

using Core.Common.Dtos;
using Core.Common.Results;
using Core.Interfaces.Providers.MedView.ReferenceDataProviders;

namespace Application.Queries.MedView.Filters.GetMedicalCareTypeFilterOptionsQuery;

public sealed class GetMedicalCareTypeFilterOptionsQueryHandler(
    IMedicalCareReferenceDataProvider medicalCareReferenceDataProvider) : IRequestHandler<GetMedicalCareTypeFilterOptionsQuery, Result<GetMedicalCareTypeFilterOptionsResult>>
{
    public async Task<Result<GetMedicalCareTypeFilterOptionsResult>> Handle(
        GetMedicalCareTypeFilterOptionsQuery request,
        CancellationToken cancellationToken)
    {
        var medicalCareTypes = await medicalCareReferenceDataProvider.GetMedicalCareTypeReferencesAsync(
            cancellationToken: cancellationToken);

        return Result<GetMedicalCareTypeFilterOptionsResult>.Success(
            new GetMedicalCareTypeFilterOptionsResult(
                Options: [.. medicalCareTypes.Select(x => new FilterOptionDto(
                    Key: x.Id.ToString(),
                    Value: x.Name))]));
    }
}
