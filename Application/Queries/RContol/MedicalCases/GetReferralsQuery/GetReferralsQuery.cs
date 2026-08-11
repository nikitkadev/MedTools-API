using MediatR;
using Core.Common.Results;
using Core.Common.Enums;

namespace Application.Queries.RContol.MedicalCases.GetReferralsQuery;

public sealed record GetReferralsQuery(
    int MedicalCaseUid,
    TargetDbType TargetDb) : IRequest<Result<GetReferralsResult>>;
