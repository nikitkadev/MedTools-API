using MediatR;

using Core.Common.Dtos;
using Core.Common.Results;
using Core.Interfaces.Providers.MedView.ReferenceDataProviders;

namespace Application.Queries.MedView.Filters.GetSurgicalTreatmentTypeFilterOptionsQuery;

public sealed class GetSurgicalTreatmentTypeFilterOptionsQueryHandler(
    IMedicalServiceReferenceDataProvider medicalServiceReferenceDataProvider) : IRequestHandler<GetSurgicalTreatmentTypeFilterOptionsQuery, Result<GetSurgicalTreatmentTypeFilterOptionsResult>>
{
    public async Task<Result<GetSurgicalTreatmentTypeFilterOptionsResult>> Handle(
        GetSurgicalTreatmentTypeFilterOptionsQuery request, 
        CancellationToken cancellationToken)
    {
        var surgicalTreatmentTypes = await medicalServiceReferenceDataProvider.GetSurgicalTreatmentTypeReferencesAsync(
            cancellationToken: cancellationToken);

        return Result<GetSurgicalTreatmentTypeFilterOptionsResult>.Success(
            new GetSurgicalTreatmentTypeFilterOptionsResult(
                FilterOptions: [.. surgicalTreatmentTypes.Select(x => new FilterOptionDto(
                    Value: x.Id.ToString(),
                    Label: x.Name))]));
    }
}
