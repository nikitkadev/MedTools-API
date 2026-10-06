using MediatR;

using Core.Common.Results;

namespace Application.Queries.MedView.Filters.GetDiagnosticMethodFilterOptionsQuery;

public sealed record GetDiagnosticMethodFilterOptionsQuery : IRequest<Result<GetDiagnosticMethodFilterOptionsResult>>;
