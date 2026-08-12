using MediatR;

using Core.Common.Results;
using Core.Common.Enums;

namespace Application.Queries.RControl.ClinicalGroups.GetClassificationCriteriaQuery;

public sealed record GetClassificationCriteriaQuery(
    int ClinicalGroupUid,
    TargetDbType TargetDb) : IRequest<Result<GetClassificationCriteriaResult>>;
