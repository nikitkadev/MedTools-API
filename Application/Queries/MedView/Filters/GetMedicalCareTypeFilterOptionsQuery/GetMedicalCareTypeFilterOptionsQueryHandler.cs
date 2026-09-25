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
                FilterOptions: [.. medicalCareTypes.Select(x => new FilterOptionDto(
                    Value: x.Id.ToString(),
                    Label: x.Name))]));
    }
}
