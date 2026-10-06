using MediatR;

using Core.Common.Results;

namespace Application.Queries.MedView.Filters.GetPaymentMethodFilterOptionsQuery;

public sealed record GetPaymentMethodFilterOptionsQuery : IRequest<Result<GetPaymentMethodFilterOptionsResult>>;
