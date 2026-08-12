using MediatR;

using Core.Common.Enums;
using Core.Common.Results;

namespace Application.Queries.RControl.MedicalCases.GetReferralsQuery;

public sealed record GetReferralsQuery(
    int MedicalCaseUid,
    TargetDbType TargetDb) : IRequest<Result<GetReferralsResult>>;
