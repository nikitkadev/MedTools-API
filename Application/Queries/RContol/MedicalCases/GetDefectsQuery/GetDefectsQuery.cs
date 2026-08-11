using MediatR;

using Core.Enums;
using Core.Common;

namespace Application.Queries.RContol.MedicalCases.GetDefectsQuery;

public sealed record GetDefectsQuery(
    int MedicalCaseUid,
    TargetDbType TargetDb,
    int Page,
    int PageSize) : IRequest<Result<GetDefectsResult>>;
