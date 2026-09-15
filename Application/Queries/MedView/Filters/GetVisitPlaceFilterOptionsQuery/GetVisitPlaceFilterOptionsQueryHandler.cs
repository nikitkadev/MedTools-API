using MediatR;

using Core.Common.Dtos;
using Core.Common.Results;
using Core.Interfaces.Providers.MedView.ReferenceDataProviders;

namespace Application.Queries.MedView.Filters.GetVisitPlaceFilterOptionsQuery;

public sealed class GetVisitPlaceFilterOptionsQueryHandler(
    IMedicalOrganizationReferenceDataProvider medicalOrganizationReferenceDataProvider) : IRequestHandler<GetVisitPlaceFilterOptionsQuery, Result<GetVisitPlaceFilterOptionsResult>>
{
    public async Task<Result<GetVisitPlaceFilterOptionsResult>> Handle(
        GetVisitPlaceFilterOptionsQuery request,
        CancellationToken cancellationToken)
    {
        var visitPlaces = await medicalOrganizationReferenceDataProvider.GetVisitPlaceReferencesAsync(
            cancellationToken: cancellationToken);

        return Result<GetVisitPlaceFilterOptionsResult>.Success(
            new GetVisitPlaceFilterOptionsResult(
                Options: [.. visitPlaces.Select(x => new FilterOptionDto(
                    Key: x.Id,
                    Value: x.Name))]));
    }
}
