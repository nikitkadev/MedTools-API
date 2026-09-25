using MediatR;

using Core.Common.Dtos;
using Core.Common.Results;
using Core.Interfaces.Providers.MedView.ReferenceDataProviders;

namespace Application.Queries.MedView.Filters.GetDrugTherapyCycleFilterOptionsQuery;

public sealed class GetDrugTherapyCycleFilterOptionsQueryHandler(
    IMedicalServiceReferenceDataProvider medicalServiceReferenceDataProvider) : IRequestHandler<GetDrugTherapyCycleFilterOptionsQuery, Result<GetDrugTherapyCycleFilterOptionsResult>>
{
    public async Task<Result<GetDrugTherapyCycleFilterOptionsResult>> Handle(
        GetDrugTherapyCycleFilterOptionsQuery request,
        CancellationToken cancellationToken)
    {
        var drugTherapyCycles = await medicalServiceReferenceDataProvider.GetDrugTherapyCycleReferencesAsync(
            cancellationToken: cancellationToken);

        return Result<GetDrugTherapyCycleFilterOptionsResult>.Success(
            new GetDrugTherapyCycleFilterOptionsResult(
                FilterOptions: [.. drugTherapyCycles.Select(x => new FilterOptionDto(
                    Value: x.Id.ToString(),
                    Label: x.Name))]));
    }
}
