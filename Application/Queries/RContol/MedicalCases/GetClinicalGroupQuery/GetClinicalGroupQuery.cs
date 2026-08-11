using MediatR;
using Core.Common.Results;
using Core.Common.Enums;

namespace Application.Queries.RContol.MedicalCases.GetClinicalGroupQuery;

public sealed record GetClinicalGroupQuery(
    int MedicalCaseUid,
    TargetDbType TargetDb) : IRequest<Result<GetClinicalGroupResult>>;
