using MediatR;

using Core.Enums;
using Core.Common;

namespace Application.Queries.RContol.MedicalCases.GetClinicalGroupQuery;

public sealed record GetClinicalGroupQuery(
    int MedicalCaseUid,
    TargetDbType TargetDb) : IRequest<Result<GetClinicalGroupResult>>;
