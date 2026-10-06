using MediatR;

using Core.Common.Dtos;
using Core.Common.Results;
using Core.Interfaces.Providers.MedView.ReferenceDataProviders;

namespace Application.Queries.MedView.Filters.GetScreeningResultFilterOptionsQuery;

public sealed class GetScreeningResultFilterOptionsQueryHandler(
    IMedicalCareReferenceDataProvider medicalCareReferenceDataProvider) : IRequestHandler<GetScreeningResultFilterOptionsQuery, Result<GetScreeningResultFilterOptionsResult>>
{
    public async Task<Result<GetScreeningResultFilterOptionsResult>> Handle(
        GetScreeningResultFilterOptionsQuery request, 
        CancellationToken cancellationToken)
    {
        var screeningResults = await medicalCareReferenceDataProvider.GetScreeningResultReferencesAsync(
            cancellationToken: cancellationToken);

        return Result<GetScreeningResultFilterOptionsResult>.Success(
            new GetScreeningResultFilterOptionsResult(
                FilterOptions: [.. screeningResults.Select(x => new FilterOptionDto(
                    Value: x.Id,
                    Label: x.Name))]));
    }
}
