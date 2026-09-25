using MediatR;

using Core.Common.Dtos;
using Core.Common.Results;
using Core.Interfaces.Providers.MedView.ReferenceDataProviders;

namespace Application.Queries.MedView.Filters.GetProvidedServiceFilterOptionsQuery;

public sealed class GetProvidedServiceFilterOptionsQueryHandler(
    IMedicalServiceReferenceDataProvider medicalServiceReferenceDataProvider) : IRequestHandler<GetProvidedServiceFilterOptionsQuery, Result<GetProvidedServiceFilterOptionsResult>>
{
    public async Task<Result<GetProvidedServiceFilterOptionsResult>> Handle(
        GetProvidedServiceFilterOptionsQuery request,
        CancellationToken cancellationToken)
    {
        var providedServices = await medicalServiceReferenceDataProvider.GetProvidedServiceReferencesAsync(
            cancellationToken: cancellationToken);

        return Result<GetProvidedServiceFilterOptionsResult>.Success(
            new GetProvidedServiceFilterOptionsResult(
                FilterOptions: [.. providedServices.Select(x => new FilterOptionDto(
                    Value: x.Id,
                    Label: x.Name))]));
    }
}
