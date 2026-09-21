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
                Options: [.. drugTherapyCycles.Select(x => new FilterOptionDto(
                    Key: x.Id.ToString(),
                    Value: x.Name))]));
    }
}
