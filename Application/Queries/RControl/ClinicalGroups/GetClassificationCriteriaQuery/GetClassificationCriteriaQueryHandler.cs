using MediatR;

using Core.Common.Results;
using Core.Interfaces.Repositories.RControl;

namespace Application.Queries.RControl.ClinicalGroups.GetClassificationCriteriaQuery;

public sealed class GetClassificationCriteriaQueryHandler(
    IClinicalGroupRepository clinicalGroupRepository) : IRequestHandler<GetClassificationCriteriaQuery, Result<GetClassificationCriteriaResult>>
{
    public async Task<Result<GetClassificationCriteriaResult>> Handle(
        GetClassificationCriteriaQuery request, 
        CancellationToken cancellationToken)
    {
        var classificationCriterions = await clinicalGroupRepository.GetClassificationCriterionsAsync(
            clinicalGroupUid: request.ClinicalGroupUid,
            targetDb: request.TargetDb,
            cancellationToken: cancellationToken);

        return Result<GetClassificationCriteriaResult>.Success(
            new GetClassificationCriteriaResult(
                ClassificationCriteria: classificationCriterions));
    }
}
