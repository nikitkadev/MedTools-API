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
            search: request.Search,
            cancellationToken: cancellationToken);

        return Result<GetDiseaseStageFilterOptionsResult>.Success(
            new GetDiseaseStageFilterOptionsResult(
                FilterOptions: [.. diseaseStages.Select(x => new FilterOptionDto(
                    Value: x.Id,
                    Label: x.Id))]));
    }
}
