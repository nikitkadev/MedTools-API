using MediatR;

using Core.Common.Results;
using Core.Common.Enums;

namespace Application.Queries.RControl.MedicalCases.GetOncologyCaseQuery;

public sealed record GetOncologyCaseQuery(
    int MedicalCaseUid,
    TargetDbType TargetDb) : IRequest<Result<GetOncologyCaseResult>>;
