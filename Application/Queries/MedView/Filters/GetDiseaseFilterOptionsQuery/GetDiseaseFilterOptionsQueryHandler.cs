using MediatR;

using Core.Common.Dtos;
using Core.Common.Results;
using Core.Interfaces.Providers.MedView.ReferenceDataProviders;

namespace Application.Queries.MedView.Filters.GetDiseaseFilterOptionsQuery;

public sealed class GetDiseaseFilterOptionsQueryHandler(
    IDiseasesReferenceDataProvider diseasesReferenceDataProvider) : IRequestHandler<GetDiseaseFilterOptionsQuery, Result<GetDiseaseFilterOptionsResult>>
{
    public async Task<Result<GetDiseaseFilterOptionsResult>> Handle(
        GetDiseaseFilterOptionsQuery request, 
        CancellationToken cancellationToken)
    {
        var diseases = await diseasesReferenceDataProvider.GetDiseaseReferencesAsync(
            search: request.Search,
            cancellationToken: cancellationToken);

        return Result<GetDiseaseFilterOptionsResult>.Success(
            new GetDiseaseFilterOptionsResult(
                FilterOptions: [.. diseases.Select(x => new FilterOptionDto(
                    Label: $"{x.Id} — {x.Name}",
                    Value: x.Id))]));
    }
}