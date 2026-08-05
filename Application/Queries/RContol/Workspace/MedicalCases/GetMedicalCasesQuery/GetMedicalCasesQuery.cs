using MediatR;

using Core.Common;
using Core.Enums;

namespace Application.Queries.RContol.Workspace.MedicalCases.GetMedicalCasesQuery;

public sealed record GetMedicalCasesQuery(
    int CompletedCaseUid,
    TargetDbType TargetDb) : IRequest<Result<GetMedicalCasesResult>>; 
