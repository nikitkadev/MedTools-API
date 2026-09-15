using MediatR;

using Core.Common.Results;
using Core.Dtos.MedView.Filters;
using Core.Interfaces.Providers.MedView.AvailableKeysProviders;
using Core.Interfaces.Providers.MedView.ReferenceDataProviders;

namespace Application.Queries.MedView.Filters.GetInsuranceFilterOptionsQuery;

public sealed class GetInsuranceFilterOptionsQueryHandler(
    IAvailableMedicalOrganizationKeysProvider availableMedicalOrganizationKeysProvider,
    IInsuranceReferenceDataProvider insuranceReferenceDataProvider) : IRequestHandler<GetInsuranceFilterOptionsQuery, Result<GetInsuranceFilterOptionsQueryResult>>
{
    public async Task<Result<GetInsuranceFilterOptionsQueryResult>> Handle(
        GetInsuranceFilterOptionsQuery request, 
        CancellationToken cancellationToken)
    {
        var insurancesKeys = await availableMedicalOrganizationKeysProvider.GetInsuranceOrganizationsKeysAsync(
            targetDb: request.TargetDb, 
            cancellationToken: cancellationToken);

        var insurancesReferenceData = await insuranceReferenceDataProvider.GetByKeysAsync(
            keys: insurancesKeys, 
            cancellationToken: cancellationToken);

        return Result<GetInsuranceFilterOptionsQueryResult>.Success(
            new GetInsuranceFilterOptionsQueryResult(
                InsuranceFilterOptions: [.. insurancesReferenceData.Select(x => new InsuranceFilterOptionsDto(Code: x.Code, Shortname: x.Name))]));
    }
}
