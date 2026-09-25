using MediatR;

using Core.Common.Results;

namespace Application.Queries.MedView.Filters.GetTherapyRegimenFilterOptionsQuery;

public sealed record GetTherapyRegimenFilterOptionsQuery(string Search) : IRequest<Result<GetTherapyRegimenFilterOptionsResult>>;
