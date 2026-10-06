using MediatR;

using Core.Common.Dtos;
using Core.Common.Results;
using Core.Interfaces.Providers.MedView.ReferenceDataProviders;

namespace Application.Queries.MedView.Filters.GetPhysicianSpecialityFilterOptionsQuery;

public class GetPhysicianSpecialityFilterOptionsQueryHandler(
    IMedicalCareReferenceDataProvider medicalCareReferenceDataProvider) : IRequestHandler<GetPhysicianSpecialityFilterOptionsQuery, Result<GetPhysicianSpecialityFilterOptionsResult>>
{
    public async Task<Result<GetPhysicianSpecialityFilterOptionsResult>> Handle(
        GetPhysicianSpecialityFilterOptionsQuery request,
        CancellationToken cancellationToken)
    {
        var physicianSpecialities = await medicalCareReferenceDataProvider.GetPhysicianSpecialtyReferencesAsync(
            cancellationToken: cancellationToken);

        return Result<GetPhysicianSpecialityFilterOptionsResult>.Success(
            new GetPhysicianSpecialityFilterOptionsResult(
                FilterOptions: [.. physicianSpecialities.Select(x => new FilterOptionDto(
                    Value: x.Id,
                    Label: x.Name))]));
    }
}
