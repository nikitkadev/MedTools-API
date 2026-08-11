using MediatR;
using Core.Common.Results;
using Core.Common.Enums;

namespace Application.Queries.RContol.ClinicalGroups.GetClassificationCriterionsQuery;

public sealed record GetClassificationCriterionsQuery(
    int ClinicalGroupUid,
    TargetDbType TargetDb) : IRequest<Result<GetClassificationCriterionsResult>>;
