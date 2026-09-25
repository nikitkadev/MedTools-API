using MediatR;

using Core.Common.Dtos;
using Core.Common.Results;
using Core.Interfaces.Providers.MedView.ReferenceDataProviders;

namespace Application.Queries.MedView.Filters.GetDiseaseOutcomeFilterOptionsQuery;

public sealed class GetDiseaseOutcomeFilterOptionsQueryHandler(
    IDiseasesReferenceDataProvider diseasesReferenceDataProvider) : IRequestHandler<GetDiseaseOutcomeFilterOptionsQuery, Result<GetDiseaseOutcomeFilterOptionsResult>>
{
    public async Task<Result<GetDiseaseOutcomeFilterOptionsResult>> Handle(
        GetDiseaseOutcomeFilterOptionsQuery request, 
        CancellationToken cancellationToken)
    {
        var diseaseOutcomes = await diseasesReferenceDataProvider.GetDiseaseOutcomeReferencesAsync(
            cancellationToken: cancellationToken);

        return Result<GetDiseaseOutcomeFilterOptionsResult>.Success(
            new GetDiseaseOutcomeFilterOptionsResult(
                FilterOptions: [.. diseaseOutcomes.Select(x => new FilterOptionDto(
                    Value: x.Id.ToString(),
                    Label: x.Name))]));
    }
}
