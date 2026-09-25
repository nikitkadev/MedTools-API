using MediatR;

using Core.Common.Dtos;
using Core.Common.Results;
using Core.Interfaces.Providers.MedView.ReferenceDataProviders;

namespace Application.Queries.MedView.Filters.GetInsurancePolicyTypeFilterOptionsQuery;

public sealed class GetInsurancePolicyTypeFilterOptionsQueryHandler(
    IDocumentReferenceDataProvider documentReferenceDataProvider) : IRequestHandler<GetInsurancePolicyTypeFilterOptionsQuery, Result<GetInsurancePolicyTypeFilterOptionsResult>>
{
    public async Task<Result<GetInsurancePolicyTypeFilterOptionsResult>> Handle(
        GetInsurancePolicyTypeFilterOptionsQuery request, 
        CancellationToken cancellationToken)
    {
        var policyTypes = await documentReferenceDataProvider.GetInsurancePolicyTypesAsync(cancellationToken: cancellationToken);

        return Result<GetInsurancePolicyTypeFilterOptionsResult>.Success(
            new GetInsurancePolicyTypeFilterOptionsResult(
                FilterOptions: [.. policyTypes.Select(x => new FilterOptionDto(
                    Value: x.TypeId, 
                    Label: x.Name))]));
    }
}