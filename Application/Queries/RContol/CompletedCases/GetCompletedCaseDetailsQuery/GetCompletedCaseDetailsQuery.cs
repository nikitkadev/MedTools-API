using MediatR;
using Core.Common.Results;
using Core.Common.Enums;

namespace Application.Queries.RContol.CompletedCases.GetCompletedCaseDetailsQuery;

public sealed record GetCompletedCaseDetailsQuery(
    int CompletedCaseUid,
    TargetDbType TargetDb) : IRequest<Result<GetCompletedCaseDetailsResult>>;
