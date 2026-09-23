using MediatR;

using Core.Common.Results;

namespace Application.Queries.MedView.Filters.GetComplexityCoefficientOptionsQuery;

public sealed record GetComplexityCoefficientOptionsQuery : IRequest<Result<GetComplexityCoefficientOptionsResult>>;
