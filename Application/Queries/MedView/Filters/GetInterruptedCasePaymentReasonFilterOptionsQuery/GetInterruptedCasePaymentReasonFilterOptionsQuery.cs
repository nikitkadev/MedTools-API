using MediatR;

using Core.Common.Results;

namespace Application.Queries.MedView.Filters.GetInterruptedCasePaymentReasonFilterOptionsQuery;

public sealed record GetInterruptedCasePaymentReasonFilterOptionsQuery : IRequest<Result<GetInterruptedCasePaymentReasonFilterOptionsResult>>;
