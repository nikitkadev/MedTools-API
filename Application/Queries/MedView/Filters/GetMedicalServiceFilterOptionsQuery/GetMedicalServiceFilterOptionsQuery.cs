using MediatR;

using Core.Common.Results;

namespace Application.Queries.MedView.Filters.GetMedicalServiceFilterOptionsQuery;

public sealed record GetMedicalServiceFilterOptionsQuery : IRequest<Result<GetMedicalServiceFilterOptionsResult>>;
