using MediatR;

using Core.Common.Dtos;
using Core.Common.Results;
using Core.Interfaces.Providers.MedView.ReferenceDataProviders;

namespace Application.Queries.MedView.Filters.GetDiseaseSubClassFilterOptionsQuery;

public sealed class GetDiseaseSubClassFilterOptionsQueryHandler(
    IDiseasesReferenceDataProvider diseasesReferenceDataProvider) : IRequestHandler<GetDiseaseSubClassFilterOptionsQuery, Result<GetDiseaseSubClassFilterOptionsResult>>
{
    public async Task<Result<GetDiseaseSubClassFilterOptionsResult>> Handle(
        GetDiseaseSubClassFilterOptionsQuery request,
        CancellationToken cancellationToken)
    {
        var diseaseSubClasses = await diseasesReferenceDataProvider.GetDiseaseSubClassReferencesAsync(
            cancellationToken: cancellationToken);

        return Result<GetDiseaseSubClassFilterOptionsResult>.Success(
            new GetDiseaseSubClassFilterOptionsResult(
                FilterOptions: [.. diseaseSubClasses.Select(x => new FilterOptionDto(
                    Label: x.Name,
                    Value: x.Id.ToString()))]));
    }
}
