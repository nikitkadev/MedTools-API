using MediatR;

using Core.Common.Dtos;
using Core.Common.Results;
using Core.Interfaces.Providers.MedView.ReferenceDataProviders;

namespace Application.Queries.MedView.Filters.GetOncologyServiceTypeFilterOptionsQuery;

public sealed class GetOncologyServiceTypeFilterOptionsQueryHandler(
    IMedicalServiceReferenceDataProvider medicalServiceReferenceDataProvider) : IRequestHandler<GetOncologyServiceTypeFilterOptionsQuery, Result<GetOncologyServiceTypeFilterOptionsResult>>
{
    public async Task<Result<GetOncologyServiceTypeFilterOptionsResult>> Handle(
        GetOncologyServiceTypeFilterOptionsQuery request,
        CancellationToken cancellationToken)
    {
        var oncologyServiceTypes = await medicalServiceReferenceDataProvider.GetOncologyServiceTypeReferencesAsync(
            cancellationToken: cancellationToken);

        return Result<GetOncologyServiceTypeFilterOptionsResult>.Success(
            new GetOncologyServiceTypeFilterOptionsResult(
                Options: [.. oncologyServiceTypes.Select(x => new FilterOptionDto(
                    Key: x.Id.ToString(),
                    Value: x.Name))]));
    }
}
