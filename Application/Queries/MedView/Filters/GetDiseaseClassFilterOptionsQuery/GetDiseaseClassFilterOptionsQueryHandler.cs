using MediatR;

using Core.Common.Dtos;
using Core.Common.Results;
using Core.Interfaces.Providers.MedView.ReferenceDataProviders;

namespace Application.Queries.MedView.Filters.GetDiseaseClassFilterOptionsQuery;

public sealed class GetDiseaseClassFilterOptionsQueryHandler(
    IDiseasesReferenceDataProvider diseasesReferenceDataProvider) : IRequestHandler<GetDiseaseClassFilterOptionsQuery, Result<GetDiseaseClassFilterOptionsResult>>
{
    public async Task<Result<GetDiseaseClassFilterOptionsResult>> Handle(
        GetDiseaseClassFilterOptionsQuery request,
        CancellationToken cancellationToken)
    {
        var diseaseClasses = await diseasesReferenceDataProvider.GetDiseaseClassReferencesAsync(
            cancellationToken: cancellationToken);

        return Result<GetDiseaseClassFilterOptionsResult>.Success(
            new GetDiseaseClassFilterOptionsResult(
                FilterOptions: [.. diseaseClasses.Select(x => new FilterOptionDto(
                    Label: x.Name,
                    Value: x.Id.ToString()))]));
    }
}