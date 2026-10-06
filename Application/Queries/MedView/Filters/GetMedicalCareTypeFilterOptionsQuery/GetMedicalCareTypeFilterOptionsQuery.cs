using MediatR;

using Core.Common.Results;

namespace Application.Queries.MedView.Filters.GetMedicalCareTypeFilterOptionsQuery;

public sealed record GetMedicalCareTypeFilterOptionsQuery : IRequest<Result<GetMedicalCareTypeFilterOptionsResult>>;
