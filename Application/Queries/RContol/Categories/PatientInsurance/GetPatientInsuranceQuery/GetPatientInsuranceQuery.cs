using MediatR;

using Core.Enums;
using Core.Common;

namespace Application.Queries.RContol.Categories.PatientInsurance.GetPatientInsuranceQuery;

public sealed record GetPatientInsuranceQuery(
    int MedicalCaseUid,
    TargetDbType TargetDb) : IRequest<Result<GetPatientInsuranceResult>>;