using MediatR;

using Core.Enums;
using Core.Common;

namespace Application.Queries.RContol.ClinicalGroups.GetClassificationCriterionsQuery;

public sealed record GetClassificationCriterionsQuery(
    int ClinicalGroupUid,
    TargetDbType TargetDb) : IRequest<Result<GetClassificationCriterionsResult>>;
