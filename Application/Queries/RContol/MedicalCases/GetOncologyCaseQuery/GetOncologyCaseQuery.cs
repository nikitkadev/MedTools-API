using MediatR;

using Core.Enums;
using Core.Common;

namespace Application.Queries.RContol.MedicalCases.GetOncologyCaseQuery;

public sealed record GetOncologyCaseQuery(
    int MedicalCaseUid,
    TargetDbType TargetDb) : IRequest<Result<GetOncologyCaseResult>>;
