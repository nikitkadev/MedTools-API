using MediatR;

using Core.Common.Dtos;
using Core.Common.Results;
using Core.Interfaces.Providers.MedView.ReferenceDataProviders;

namespace Application.Queries.MedView.Filters.GetTherapyRegimenFilterOptionsQuery;

public sealed class GetTherapyRegimenFilterOptionsQueryHandler(
    IMedicalServiceReferenceDataProvider medicalServiceReferenceDataProvider) : IRequestHandler<GetTherapyRegimenFilterOptionsQuery, Result<GetTherapyRegimenFilterOptionsResult>>
{
    public async Task<Result<GetTherapyRegimenFilterOptionsResult>> Handle(
        GetTherapyRegimenFilterOptionsQuery request,
        CancellationToken cancellationToken)
    {
        var therapyRegimens = await medicalServiceReferenceDataProvider.GetTherapyRegimenReferencesAsync(
            cancellationToken: cancellationToken);

        return Result<GetTherapyRegimenFilterOptionsResult>.Success(
            new GetTherapyRegimenFilterOptionsResult(
                Options: [.. therapyRegimens.Select(x => new FilterOptionDto(
                    Key: x.Id,
                    Value: x.Name))]));
    }
}
