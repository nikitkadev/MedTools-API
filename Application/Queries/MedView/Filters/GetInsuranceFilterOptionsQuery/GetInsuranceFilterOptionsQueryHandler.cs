using MediatR;

using Core.Common.Enums;
using Core.Common.Results;
using Core.Dtos.MedView.Filters;
using Core.Interfaces.Providers.MedView.AvailableOrganizationsProvider;

namespace Application.Queries.MedView.Filters.GetInsuranceFilterOptionsQuery;

public sealed class GetInsuranceFilterOptionsQueryHandler(
    IAvailableMedicalOrganizationsProvider availableMedicalOrganizationsProvider) : IRequestHandler<GetInsuranceFilterOptionsQuery, Result<GetInsuranceFilterOptionsQueryResult>>
{
    public async Task<Result<GetInsuranceFilterOptionsQueryResult>> Handle(
        GetInsuranceFilterOptionsQuery request, 
        CancellationToken cancellationToken)
    {
        var availableInsurance = await availableMedicalOrganizationsProvider.GetInsuranceAsync(
            targetDb: TargetDbType.SMODB18, 
            cancellationToken: cancellationToken);

        var filterOptions = availableInsurance
            .Select(x => new InsuranceFilterOptionsDto(Code: x.Code, Shortname: x.Name))
            .ToList();

        return Result<GetInsuranceFilterOptionsQueryResult>.Success(
            new GetInsuranceFilterOptionsQueryResult(
                InsuranceFilterOptions: filterOptions));
    }
}
