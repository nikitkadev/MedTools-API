using MediatR;

using Core.Common.Dtos;
using Core.Common.Results;
using Core.Interfaces.Providers.MedView.ReferenceDataProviders;

namespace Application.Queries.MedView.Filters.GetVisitPurposeFilterOptionsQuery;

public sealed class GetVisitPurposeFilterOptionsQueryHandler(
    IMedicalOrganizationReferenceDataProvider medicalOrganizationReferenceDataProvider) : IRequestHandler<GetVisitPurposeFilterOptionsQuery, Result<GetVisitPurposeFilterOptionsResult>>
{
    public async Task<Result<GetVisitPurposeFilterOptionsResult>> Handle(
        GetVisitPurposeFilterOptionsQuery request, 
        CancellationToken cancellationToken)
    {
        var visitPurposes = await medicalOrganizationReferenceDataProvider.GetVisitPurposeReferencesAsync(
            cancellationToken: cancellationToken);

        return Result<GetVisitPurposeFilterOptionsResult>.Success(
            new GetVisitPurposeFilterOptionsResult(
                Options: [.. visitPurposes.Select(x => new FilterOptionDto(
                    Key: x.Id,
                    Value: x.Name))]));
    }
}
