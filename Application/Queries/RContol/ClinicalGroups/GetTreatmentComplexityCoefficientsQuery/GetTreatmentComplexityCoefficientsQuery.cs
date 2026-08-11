using Core.Common.Enums;
using Core.Common.Results;
using MediatR;

namespace Application.Queries.RContol.ClinicalGroups.GetTreatmentComplexityCoefficientsQuery;

public sealed record GetTreatmentComplexityCoefficientsQuery(
    int ClinicalGroupUid,
    TargetDbType TargetDb) : IRequest<Result<GetTreatmentComplexityCoefficientsResult>>;
