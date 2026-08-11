using MediatR;
using Core.Common.Results;
using Core.Common.Enums;

namespace Application.Queries.RContol.MedicalCases.GetDefectsQuery;

public sealed record GetDefectsQuery(
    int MedicalCaseUid,
    TargetDbType TargetDb,
    int Page,
    int PageSize) : IRequest<Result<GetDefectsResult>>;
