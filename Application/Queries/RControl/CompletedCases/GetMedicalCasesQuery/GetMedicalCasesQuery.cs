using MediatR;

using Core.Common.Results;
using Core.Common.Enums;

namespace Application.Queries.RControl.CompletedCases.GetMedicalCasesQuery;

public sealed record GetMedicalCasesQuery(
    int CompletedCaseUid,
    TargetDbType TargetDb) : IRequest<Result<GetMedicalCasesResult>>; 
