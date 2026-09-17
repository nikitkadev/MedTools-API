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
                Options: [.. diseaseOutcomes.Select(x => new FilterOptionDto(
                    Key: x.Id.ToString(),
                    Value: x.Name))]));
    }
}
