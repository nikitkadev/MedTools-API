using MediatR;

using Core.Enums;
using Core.Common;

namespace Application.Queries.RContol.MedicalCases.GetReferralsQuery;

public sealed record GetReferralsQuery(
    int MedicalCaseUid,
    TargetDbType TargetDb) : IRequest<Result<GetReferralsResult>>;
