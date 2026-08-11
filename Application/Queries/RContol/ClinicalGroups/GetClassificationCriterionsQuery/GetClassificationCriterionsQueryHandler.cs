using MediatR;
using Core.Common.Results;
using Core.Interfaces.Repositories.RControl;

namespace Application.Queries.RContol.ClinicalGroups.GetClassificationCriterionsQuery;

public class GetClassificationCriterionsQueryHandler(
    IClinicalGroupRepository clinicalGroupRepository) : IRequestHandler<GetClassificationCriterionsQuery, Result<GetClassificationCriterionsResult>>
{
    public async Task<Result<GetClassificationCriterionsResult>> Handle(
        GetClassificationCriterionsQuery request, 
        CancellationToken cancellationToken)
    {
        var classificationCriterions = await clinicalGroupRepository.GetClassificationCriterionsAsync(
            clinicalGroupUid: request.ClinicalGroupUid,
            targetDb: request.TargetDb,
            cancellationToken: cancellationToken);

        return Result<GetClassificationCriterionsResult>.Success(
            new GetClassificationCriterionsResult(
                ClassificationCriterions: classificationCriterions));
    }
}
