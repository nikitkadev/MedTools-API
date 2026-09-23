using MediatR;

using Core.Common.Dtos;
using Core.Common.Results;
using Core.Interfaces.Providers.MedView.ReferenceDataProviders;

namespace Application.Queries.MedView.Filters.GetInterruptedCasePaymentReasonFilterOptionsQuery;

public sealed class GetInterruptedCasePaymentReasonFilterOptionsQueryHandler(
    IMedicalServiceReferenceDataProvider medicalServiceReferenceDataProvider) : IRequestHandler<GetInterruptedCasePaymentReasonFilterOptionsQuery, Result<GetInterruptedCasePaymentReasonFilterOptionsResult>>
{
    public async Task<Result<GetInterruptedCasePaymentReasonFilterOptionsResult>> Handle(
        GetInterruptedCasePaymentReasonFilterOptionsQuery request,
        CancellationToken cancellationToken)
    {
        var interruptedCasePaymentReasons = await medicalServiceReferenceDataProvider.GetInterruptedCasePaymentReasonReferencesAsync(
            cancellationToken: cancellationToken);

        return Result<GetInterruptedCasePaymentReasonFilterOptionsResult>.Success(
            new GetInterruptedCasePaymentReasonFilterOptionsResult(
                Options: [.. interruptedCasePaymentReasons.Select(x => new FilterOptionDto(
                    Key: x.Id,
                    Value: x.Name))]));
    }
}
