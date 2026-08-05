using MediatR;

using Core.Common;
using Core.Interfaces.Repositories.Categories;
using Core.Dtos.RControl.Categories.KsgVmp;

namespace Application.Queries.RContol.Categories.KsgVmp.GetKsgVmpCardsDataCommand;

public class GetKsgVmpCardsDataCommandHandler(
    IKsgVmpCategoryRepository ksgVmpCategoryRepository) : IRequestHandler<GetKsgVmpCardsDataCommand, Result<KsgVmpCardsDataQueryResult>>
{
    public async Task<Result<KsgVmpCardsDataQueryResult>> Handle(
        GetKsgVmpCardsDataCommand request, 
        CancellationToken cancellationToken)
    {
        return await ksgVmpCategoryRepository.GetCardsDataAsync(
            sluchUid: request.SluchUid,
            targetDb: request.TargetDb);
    }
}
