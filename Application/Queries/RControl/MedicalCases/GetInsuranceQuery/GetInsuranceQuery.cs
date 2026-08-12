using MediatR;

using Core.Common.Results;
using Core.Common.Enums;

namespace Application.Queries.RControl.MedicalCases.GetInsuranceQuery;

public sealed record GetInsuranceQuery(
    int MedicalCaseUid,
    TargetDbType TargetDb) : IRequest<Result<GetInsuranceResult>>;
