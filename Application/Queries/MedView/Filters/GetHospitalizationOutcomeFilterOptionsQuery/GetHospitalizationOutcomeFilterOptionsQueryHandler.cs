using MediatR;

using Core.Common.Dtos;
using Core.Common.Results;
using Core.Interfaces.Providers.MedView.ReferenceDataProviders;

namespace Application.Queries.MedView.Filters.GetHospitalizationOutcomeFilterOptionsQuery;

public sealed class GetHospitalizationOutcomeFilterOptionsQueryHandler(
    IMedicalCareReferenceDataProvider medicalCareReferenceDataProvider) : IRequestHandler<GetHospitalizationOutcomeFilterOptionsQuery, Result<GetHospitalizationOutcomeFilterOptionsResult>>
{
    public async Task<Result<GetHospitalizationOutcomeFilterOptionsResult>> Handle(
        GetHospitalizationOutcomeFilterOptionsQuery request, 
        CancellationToken cancellationToken)
    {
        var hospitalizationOutcomes = await medicalCareReferenceDataProvider.GetHospitalizationOutcomeReferencesAsync(
            cancellationToken: cancellationToken);

        var careConditions = await medicalCareReferenceDataProvider.GetCareConditionReferencesAsync(
            cancellationToken: cancellationToken);

        return Result<GetHospitalizationOutcomeFilterOptionsResult>.Success(
            new GetHospitalizationOutcomeFilterOptionsResult(
                Options: [.. hospitalizationOutcomes.Select(x => new FilterOptionDto(
                    Key: x.Id.ToString(),
                    Value: $"{x.Name} ({careConditions.Where(careCondition => careCondition.Id == x.CareConditionId).Select(x => x.Name).First()})"))]));
    }
}