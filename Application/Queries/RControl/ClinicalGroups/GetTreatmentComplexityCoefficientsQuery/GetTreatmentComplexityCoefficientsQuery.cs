using MediatR;

using Core.Common.Enums;
using Core.Common.Results;

namespace Application.Queries.RControl.ClinicalGroups.GetTreatmentComplexityCoefficientsQuery;

public sealed record GetTreatmentComplexityCoefficientsQuery(
    int ClinicalGroupUid,
    TargetDbType TargetDb) : IRequest<Result<GetTreatmentComplexityCoefficientsResult>>;
