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
                Options: [.. careForms.Select(x => new FilterOptionDto(
                    Key: x.Id.ToString(),
                    Value: x.Name))]));
    }
}
