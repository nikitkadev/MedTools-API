using MediatR;
using Core.Common.Results;
using Core.Common.Enums;

namespace Application.Queries.RControl.MedicalCases.GetMedicalCaseDetailsQuery;

public sealed record GetMedicalCaseDetailsQuery(
    int MedicalCaseUid,
    TargetDbType TargetDb) : IRequest<Result<GetMedicalCaseDetailsResult>>;
