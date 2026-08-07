using MediatR;

using Core.Enums;
using Core.Common;

namespace Application.Queries.RContol.Oncology.GetDignosticsQuery;

public sealed record GetDignosticsQuery(
    int OncologyCaseUid,
    TargetDbType TargetDb) : IRequest<Result<GetDignosticsResult>>;
