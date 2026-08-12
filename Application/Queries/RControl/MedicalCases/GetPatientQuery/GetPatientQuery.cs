using MediatR;

using Core.Common.Results;
using Core.Common.Enums;

namespace Application.Queries.RControl.MedicalCases.GetPatientQuery;

public sealed record GetPatientQuery(
    int MedicalCaseUid,
    TargetDbType TargetDb) : IRequest<Result<GetPatientResult>>;
