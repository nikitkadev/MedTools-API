using Core.Common;
using Core.Enums;
using MediatR;

namespace Application.Queries.RContol.ClinicalGroups.GetTreatmentComplexityCoefficientsQuery;

public sealed record GetTreatmentComplexityCoefficientsQuery(
    int ClinicalGroupUid,
    TargetDbType TargetDb) : IRequest<Result<GetTreatmentComplexityCoefficientsResult>>;
