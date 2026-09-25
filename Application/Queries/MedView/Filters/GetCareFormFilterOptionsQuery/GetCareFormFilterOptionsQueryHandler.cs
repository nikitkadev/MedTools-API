using MediatR;

using Core.Common.Dtos;
using Core.Common.Results;
using Core.Interfaces.Providers.MedView.ReferenceDataProviders;

namespace Application.Queries.MedView.Filters.GetCareFormFilterOptionsQuery;

public sealed class GetCareFormFilterOptionsQueryHandler(
    IMedicalCareReferenceDataProvider medicalCareReferenceDataProvider) : IRequestHandler<GetCareFormFilterOptionsQuery, Result<GetCareFormFilterOptionsResult>>
{
    public async Task<Result<GetCareFormFilterOptionsResult>> Handle(
        GetCareFormFilterOptionsQuery request,
        CancellationToken cancellationToken)
    {
        var careForms = await medicalCareReferenceDataProvider.GetCareFormReferencesAsync(
            cancellationToken: cancellationToken);

        return Result<GetCareFormFilterOptionsResult>.Success(
            new GetCareFormFilterOptionsResult(
                FilterOptions: [.. careForms.Select(x => new FilterOptionDto(
                    Value: x.Id.ToString(),
                    Label: x.Name))]));
    }
}
