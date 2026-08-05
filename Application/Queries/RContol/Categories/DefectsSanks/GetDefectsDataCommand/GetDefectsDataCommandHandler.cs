using MediatR;

using Core.Common;
using Core.Interfaces.Repositories.Categories;
using Core.Dtos.RControl.Categories.DefectsSanks;

namespace Application.Queries.RContol.Categories.DefectsSanks.GetDefectsDataCommand;

public class GetDefectsDataCommandHandler(
    IDefectsSanksCategoryRepository defectsSanksCategoryRepository) : IRequestHandler<GetDefectsDataCommand, Result<DefectsQueryResult>>
{
    public async Task<Result<DefectsQueryResult>> Handle(
        GetDefectsDataCommand request, 
        CancellationToken cancellationToken)
    {
        return await defectsSanksCategoryRepository.GetDefectsAsync(
            sluchUid: request.SluchUid,
            targetDb: request.TargetDb,
            page: request.Page,
            pageSize: request.PageSize);
    }
}
