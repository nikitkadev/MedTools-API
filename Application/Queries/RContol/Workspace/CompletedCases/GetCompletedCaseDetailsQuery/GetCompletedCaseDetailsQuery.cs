using MediatR;

using Core.Enums;
using Core.Common;

namespace Application.Queries.RContol.Workspace.CompletedCases.GetCompletedCaseDetailsQuery;

public sealed record GetCompletedCaseDetailsQuery(
    int CompletedCaseUid,
    TargetDbType TargetDb) : IRequest<Result<GetCompletedCaseDetailsResult>>;
