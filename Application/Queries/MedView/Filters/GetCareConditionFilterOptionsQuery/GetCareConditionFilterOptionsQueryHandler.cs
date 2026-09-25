using MediatR;

using Core.Common.Dtos;
using Core.Common.Results;
using Core.Interfaces.Providers.MedView.ReferenceDataProviders;

namespace Application.Queries.MedView.Filters.GetCareConditionFilterOptionsQuery;

public class GetCareConditionFilterOptionsQueryHandler(
    IMedicalCareReferenceDataProvider medicalCareReferenceDataProvider) : IRequestHandler<GetCareConditionFilterOptionsQuery, Result<GetCareConditionFilterOptionsResult>>
{
    public async Task<Result<GetCareConditionFilterOptionsResult>> Handle(
        GetCareConditionFilterOptionsQuery request, 
        CancellationToken cancellationToken)
    {
        var careConditions = await medicalCareReferenceDataProvider.GetCareConditionReferencesAsync(
            cancellationToken: cancellationToken);

        return Result<GetCareConditionFilterOptionsResult>.Success(
            new GetCareConditionFilterOptionsResult(
                FilterOptions: [.. careConditions.Select(x => new FilterOptionDto(
                    Value: x.Id.ToString(),
                    Label: x.Name))]));
    }
}
