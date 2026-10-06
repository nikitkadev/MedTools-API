using MediatR;

using Core.Common.Results;

namespace Application.Queries.MedView.Filters.GetMedicalServiceFilterOptionsQuery;

public sealed record GetMedicalServiceFilterOptionsQuery(string Search) : IRequest<Result<GetMedicalServiceFilterOptionsResult>>;
