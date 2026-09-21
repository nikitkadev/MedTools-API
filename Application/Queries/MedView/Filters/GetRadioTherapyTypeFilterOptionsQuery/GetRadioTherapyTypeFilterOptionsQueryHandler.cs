using MediatR;

using Core.Common.Dtos;
using Core.Common.Results;
using Core.Interfaces.Providers.MedView.ReferenceDataProviders;

namespace Application.Queries.MedView.Filters.GetRadioTherapyTypeFilterOptionsQuery;

public sealed class GetRadioTherapyTypeFilterOptionsQueryHandler(
    IMedicalServiceReferenceDataProvider medicalServiceReferenceDataProvider) : IRequestHandler<GetRadioTherapyTypeFilterOptionsQuery, Result<GetRadioTherapyTypeFilterOptionsResult>>
{
    public async Task<Result<GetRadioTherapyTypeFilterOptionsResult>> Handle(
        GetRadioTherapyTypeFilterOptionsQuery request,
        CancellationToken cancellationToken)
    {
        var radioTherapyTypes = await medicalServiceReferenceDataProvider.GetRadioTherapyTypeReferencesAsync(
            cancellationToken: cancellationToken);

        return Result<GetRadioTherapyTypeFilterOptionsResult>.Success(
            new GetRadioTherapyTypeFilterOptionsResult(
                Options: [.. radioTherapyTypes.Select(x => new FilterOptionDto(
                    Key: x.Id.ToString(),
                    Value: x.Name))]));
    }
}
