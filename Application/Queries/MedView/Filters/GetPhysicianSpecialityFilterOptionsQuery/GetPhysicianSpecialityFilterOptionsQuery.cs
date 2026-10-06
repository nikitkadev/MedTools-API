using MediatR;

using Core.Common.Results;

namespace Application.Queries.MedView.Filters.GetPhysicianSpecialityFilterOptionsQuery;

public sealed record GetPhysicianSpecialityFilterOptionsQuery : IRequest<Result<GetPhysicianSpecialityFilterOptionsResult>>;
