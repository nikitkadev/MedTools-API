using MediatR;

using Core.Common.Dtos;
using Core.Common.Results;
using Core.Interfaces.Providers.MedView.ReferenceDataProviders;

namespace Application.Queries.MedView.Filters.GetDiseaseStageFilterOptionsQuery;

public sealed class GetDiseaseStageFilterOptionsQueryHandler(
    IDiseasesReferenceDataProvider diseasesReferenceDataProvider) : IRequestHandler<GetDiseaseStageFilterOptionsQuery, Result<GetDiseaseStageFilterOptionsResult>>
{
    public async Task<Result<GetDiseaseStageFilterOptionsResult>> Handle(GetDiseaseStageFilterOptionsQuery request, CancellationToken cancellationToken)
    {
        var diseaseStages = await diseasesReferenceDataProvider.GetDiseaseStageReferencesAsync(
            cancellationToken: cancellationToken);

        return Result<GetDiseaseStageFilterOptionsResult>.Success(
            new GetDiseaseStageFilterOptionsResult(
                Options: [.. diseaseStages.Select(x => new FilterOptionDto(
                    Key: x.Id.ToString(),
                    Value: x.Name))]));
    }
}
