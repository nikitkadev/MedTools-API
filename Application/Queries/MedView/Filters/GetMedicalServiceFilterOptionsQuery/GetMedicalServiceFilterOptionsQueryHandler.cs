using MediatR;

using Core.Common.Dtos;
using Core.Common.Results;
using Core.Interfaces.Providers.MedView.ReferenceDataProviders;

namespace Application.Queries.MedView.Filters.GetMedicalServiceFilterOptionsQuery;

public sealed class GetMedicalServiceFilterOptionsQueryHandler(
    IMedicalServiceReferenceDataProvider medicalServiceReferenceDataProvider) : IRequestHandler<GetMedicalServiceFilterOptionsQuery, Result<GetMedicalServiceFilterOptionsResult>>
{
    public async Task<Result<GetMedicalServiceFilterOptionsResult>> Handle(
        GetMedicalServiceFilterOptionsQuery request,
        CancellationToken cancellationToken)
    {
        var medicalServices = await medicalServiceReferenceDataProvider.GetMedicalServiceReferencesAsync(
            cancellationToken: cancellationToken);

        return Result<GetMedicalServiceFilterOptionsResult>.Success(
            new GetMedicalServiceFilterOptionsResult(
                Options: [.. medicalServices.Select(x => new FilterOptionDto(
                    Key: x.Id.ToString(),
                    Value: $"{x.Code} — {x.Name}" ))]));
    }
}
