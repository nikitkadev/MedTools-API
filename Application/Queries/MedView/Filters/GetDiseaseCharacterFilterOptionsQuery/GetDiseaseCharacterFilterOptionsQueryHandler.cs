using MediatR;

using Core.Common.Dtos;
using Core.Common.Results;
using Core.Interfaces.Providers.MedView.ReferenceDataProviders;

namespace Application.Queries.MedView.Filters.GetDiseaseCharacterFilterOptionsQuery;

public sealed class GetDiseaseCharacterFilterOptionsQueryHandler(
    IDiseasesReferenceDataProvider diseasesReferenceDataProvider) : IRequestHandler<GetDiseaseCharacterFilterOptionsQuery, Result<GetDiseaseCharacterFilterOptionsResult>>
{
    public async Task<Result<GetDiseaseCharacterFilterOptionsResult>> Handle(
        GetDiseaseCharacterFilterOptionsQuery request, 
        CancellationToken cancellationToken)
    {
        var diseaseCharacters = await diseasesReferenceDataProvider.GetDiseaseCharacterReferencesAsync(
            cancellationToken: cancellationToken);

        return Result<GetDiseaseCharacterFilterOptionsResult>.Success(
            new GetDiseaseCharacterFilterOptionsResult(
                FilterOptions: [.. diseaseCharacters.Select(x => new FilterOptionDto(
                    Value: x.Id.ToString(),
                    Label: x.Name))]));
    }
}
