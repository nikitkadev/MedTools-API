using MediatR;

using Core.Common.Dtos;
using Core.Common.Results;
using Core.Interfaces.Providers.MedView.ReferenceDataProviders;

namespace Application.Queries.MedView.Filters.GetDrugIdentifierFilterOptionsQuery;

public sealed class GetDrugIdentifierFilterOptionsQueryHandler(
    IMedicalServiceReferenceDataProvider medicalServiceReferenceDataProvider) : IRequestHandler<GetDrugIdentifierFilterOptionsQuery, Result<GetDrugIdentifierFilterOptionsResult>>
{
    public async Task<Result<GetDrugIdentifierFilterOptionsResult>> Handle(
        GetDrugIdentifierFilterOptionsQuery request,
        CancellationToken cancellationToken)
    {
        var drugIdentifiers = await medicalServiceReferenceDataProvider.GetDrugIdentifierReferencesAsync(
            cancellationToken: cancellationToken);

        return Result<GetDrugIdentifierFilterOptionsResult>.Success(
            new GetDrugIdentifierFilterOptionsResult(
                Options: [.. drugIdentifiers.Select(x => new FilterOptionDto(
                    Key: x.Id,
                    Value: x.Name))]));
    }
}
