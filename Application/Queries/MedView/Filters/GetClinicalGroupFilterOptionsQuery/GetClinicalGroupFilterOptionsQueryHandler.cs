using MediatR;

using Core.Common.Dtos;
using Core.Common.Results;
using Core.Interfaces.Providers.MedView.ReferenceDataProviders;

namespace Application.Queries.MedView.Filters.GetClinicalGroupFilterOptionsQuery;

public sealed class GetClinicalGroupFilterOptionsQueryHandler(
    IPaymentReferenceDataProvider paymentReferenceDataProvider) : IRequestHandler<GetClinicalGroupFilterOptionsQuery, Result<GetClinicalGroupFilterOptionsResult>>
{
    public async Task<Result<GetClinicalGroupFilterOptionsResult>> Handle(
        GetClinicalGroupFilterOptionsQuery request,
        CancellationToken cancellationToken)
    {
        var clinicalGroups = await paymentReferenceDataProvider.GetClinicalGroupReferencesAsync(
            cancellationToken: cancellationToken);

        return Result<GetClinicalGroupFilterOptionsResult>.Success(
            new GetClinicalGroupFilterOptionsResult(
                FilterOptions: [.. clinicalGroups.Select(x => new FilterOptionDto(
                    Value: x.Id,
                    Label: x.Name))]));
    }
}
