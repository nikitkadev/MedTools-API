using MediatR;

using Core.Enums;
using Core.Common;

namespace Application.Queries.RContol.Categories.PatientInsurance.GetPaientInsuranceQuery;

public sealed record GetPaientInsuranceQuery(
    int MedicalCaseUid,
    TargetDbType TargetDb) : IRequest<Result<GetPaientInsuranceResult>>;