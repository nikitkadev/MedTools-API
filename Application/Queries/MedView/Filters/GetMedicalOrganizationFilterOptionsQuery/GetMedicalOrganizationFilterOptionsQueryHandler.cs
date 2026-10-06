using MediatR;

using Core.Common.Dtos;
using Core.Common.Results;
using Core.Interfaces.Providers.MedView.AvailableKeysProviders;
using Core.Interfaces.Providers.MedView.ReferenceDataProviders;

namespace Application.Queries.MedView.Filters.GetMedicalOrganizationFilterOptionsQuery;

public sealed class GetMedicalOrganizationFilterOptionsQueryHandler(
    IAvailableMedicalOrganizationKeysProvider availableMedicalOrganizationKeysProvider,
    IMedicalOrganizationReferenceDataProvider medicalOrganizationReferenceDataProvider) : IRequestHandler<GetMedicalOrganizationFilterOptionsQuery, Result<GetMedicalOrganizationFilterOptionsResult>>
{
    public async Task<Result<GetMedicalOrganizationFilterOptionsResult>> Handle(
        GetMedicalOrganizationFilterOptionsQuery request,
        CancellationToken cancellationToken)
    {
        var medicalOrganizationsKeys = await availableMedicalOrganizationKeysProvider.GetMedicalOrganizationsKeysAsync(
            targetDb: request.TargetDb,
            medicalOrgsKeysFrom: request.MedicalOrgsKeysFrom,
            cancellationToken: cancellationToken);

        var medicalOrganizations = await medicalOrganizationReferenceDataProvider.GetMedicalOrganizationsByKeysAsync(
            keys: medicalOrganizationsKeys,
            cancellationToken: cancellationToken);

        return Result<GetMedicalOrganizationFilterOptionsResult>.Success(
            new GetMedicalOrganizationFilterOptionsResult(
                FilterOptions: [.. medicalOrganizations.Select(x => new FilterOptionDto(
                    Value: x.Code,
                    Label: x.Name))]));

    }
}
