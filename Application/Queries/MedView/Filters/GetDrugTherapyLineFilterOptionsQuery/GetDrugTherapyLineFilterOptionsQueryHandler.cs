using MediatR;

using Core.Common.Dtos;
using Core.Common.Results;
using Core.Interfaces.Providers.MedView.ReferenceDataProviders;

namespace Application.Queries.MedView.Filters.GetDrugTherapyLineFilterOptionsQuery;

public class GetDrugTherapyLineFilterOptionsQueryHandler(
    IMedicalServiceReferenceDataProvider medicalServiceReferenceDataProvider) : IRequestHandler<GetDrugTherapyLineFilterOptionsQuery, Result<GetDrugTherapyLineFilterOptionsResult>>
{
    public async Task<Result<GetDrugTherapyLineFilterOptionsResult>> Handle(
        GetDrugTherapyLineFilterOptionsQuery request,
        CancellationToken cancellationToken)
    {
        var drugTherapyLines = await medicalServiceReferenceDataProvider.GetDrugTherapyLineReferencesAsync(
            cancellationToken: cancellationToken);

        return Result<GetDrugTherapyLineFilterOptionsResult>.Success(
            new GetDrugTherapyLineFilterOptionsResult(
                FilterOptions: [.. drugTherapyLines.Select(x => new FilterOptionDto(
                    Value: x.Id.ToString(),
                    Label: x.Name))]));
    }
}
