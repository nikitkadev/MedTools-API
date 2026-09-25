using MediatR;

using Core.Common.Dtos;
using Core.Common.Results;
using Core.Interfaces.Providers.MedView.ReferenceDataProviders;

namespace Application.Queries.MedView.Filters.GetHighTechCareMethodFilterOptionsQuery;

public sealed class GetHighTechCareMethodFilterOptionsQueryHandler(
    IMedicalCareReferenceDataProvider medicalCareReferenceDataProvider) : IRequestHandler<GetHighTechCareMethodFilterOptionsQuery, Result<GetHighTechCareMethodFilterOptionsResult>>
{
    public async Task<Result<GetHighTechCareMethodFilterOptionsResult>> Handle(
        GetHighTechCareMethodFilterOptionsQuery request,
        CancellationToken cancellationToken)
    {
        var highTechCareMethods = await medicalCareReferenceDataProvider.GetHighTechCareMethodReferencesAsync(
            cancellationToken: cancellationToken);

        return Result<GetHighTechCareMethodFilterOptionsResult>.Success(
            new GetHighTechCareMethodFilterOptionsResult(
                FilterOptions: [.. highTechCareMethods.Select(x => new FilterOptionDto(
                    Value: x.Id,
                    Label: x.Name))]));
    }
}
