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
                Options: [.. drugTherapyLines.Select(x => new FilterOptionDto(
                    Key: x.Id.ToString(),
                    Value: x.Name))]));
    }
}
