using MediatR;

using Core.Common.Results;

namespace Application.Queries.MedView.Filters.GetDrugIdentifierFilterOptionsQuery;

public sealed record GetDrugIdentifierFilterOptionsQuery : IRequest<Result<GetDrugIdentifierFilterOptionsResult>>;
