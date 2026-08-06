using MediatR;

using Core.Enums;
using Core.Common;

namespace Application.Queries.RContol.Workspace.MedicalCases.GetMedicalCaseDetailsQuery;

public sealed record GetMedicalCaseDetailsQuery(
    int MedicalCaseUid,
    TargetDbType TargetDb) : IRequest<Result<GetMedicalCaseDetailsResult>>;
