using MediatR;

using Core.Common.Results;

namespace Application.Queries.MedView.Filters.GetMedicalCareProfileFilterOptionsQuery;

public sealed record GetMedicalCareProfileFilterOptionsQuery : IRequest<Result<GetMedicalCareProfileFilterOptionsResult>>;