using MediatR;

using Core.Common.Results;
using Core.Dtos.MedView.Filters;
using Core.Interfaces.Providers.MedView.AvailableKeysProviders;
using Core.Interfaces.Providers.MedView.ReferenceDataProviders;

namespace Application.Queries.MedView.Filters.GetInsuranceFilterOptionsQuery;

public sealed class GetInsuranceFilterOptionsQueryHandler(
    IAvailableMedicalOrganizationKeysProvider availableMedicalOrganizationKeysProvider,
    IInsuranceReferenceDataProvider insuranceReferenceDataProvider) : IRequestHandler<GetInsuranceFilterOptionsQuery, Result<GetInsuranceFilterOptionsResult>>
{
    public async Task<Result<GetInsuranceFilterOptionsResult>> Handle(
        GetInsuranceFilterOptionsQuery request, 
        CancellationToken cancellationToken)
    {
        var insurancesKeys = await availableMedicalOrganizationKeysProvider.GetInsuranceOrganizationsKeysAsync(
            targetDb: request.TargetDb, 
            cancellationToken: cancellationToken);

        var insurancesReferenceData = await insuranceReferenceDataProvider.GetByKeysAsync(
            keys: insurancesKeys, 
            cancellationToken: cancellationToken);

        return Result<GetInsuranceFilterOptionsResult>.Success(
            new GetInsuranceFilterOptionsResult(
                Options: [.. insurancesReferenceData.Select(x => new InsuranceFilterOptionsDto(Key: x.Code, Value: x.Name))]));
    }
}
