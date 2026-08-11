using MediatR;
using Core.Common.Results;
using Core.Common.Enums;

namespace Application.Queries.RContol.OncologyCases.GetDignosticsQuery;

public sealed record GetDignosticsQuery(
    int OncologyCaseUid,
    TargetDbType TargetDb) : IRequest<Result<GetDignosticsResult>>;
