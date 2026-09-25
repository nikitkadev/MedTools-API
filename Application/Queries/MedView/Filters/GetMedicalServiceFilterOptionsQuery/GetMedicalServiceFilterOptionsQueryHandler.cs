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
                FilterOptions: [.. medicalServices.Select(x => new FilterOptionDto(
                    Value: x.Id.ToString(),
                    Label: $"{x.Code} — {x.Name}" ))]));
    }
}
