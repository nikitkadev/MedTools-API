using MediatR;

using Core.Common.Dtos;
using Core.Common.Results;
using Core.Interfaces.Providers.MedView.ReferenceDataProviders;

namespace Application.Queries.MedView.Filters.GetHighTechCareFilterOptionsQuery;

public sealed class GetHighTechCareFilterOptionsQueryHandler(
    IMedicalCareReferenceDataProvider medicalCareReferenceDataProvider) : IRequestHandler<GetHighTechCareFilterOptionsQuery, Result<GetHighTechCareFilterOptionsResult>>
{
    public async Task<Result<GetHighTechCareFilterOptionsResult>> Handle(
        GetHighTechCareFilterOptionsQuery request,
        CancellationToken cancellationToken)
    {
        var highTechCareTypes = await medicalCareReferenceDataProvider.GetHighTechCareTypeReferencesAsync(
            cancellationToken: cancellationToken);

        return Result<GetHighTechCareFilterOptionsResult>.Success(
            new GetHighTechCareFilterOptionsResult(
                FilterOptions: [.. highTechCareTypes.Select(x => new FilterOptionDto(
                    Value: x.Id,
                    Label: x.Name))]));
    }
}
