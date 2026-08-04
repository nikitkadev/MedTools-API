using MediatR;

using Core.Common;
using Core.Dtos.Categories.KsgVmp;
using Core.Interfaces.Repositories.Categories;

namespace Application.Queries.RContol.Categories.KsgVmp.GetKsgVmpTablesDataCommand;

public class GetKsgVmpTablesDataCommandHandler(
    IKsgVmpCategoryRepository ksgVmpCategoryRepository) : IRequestHandler<GetKsgVmpTablesDataCommand, Result<KsgVmpTablesQueryResult>>
{
    public async Task<Result<KsgVmpTablesQueryResult>> Handle(
        GetKsgVmpTablesDataCommand request, 
        CancellationToken cancellationToken)
    {
        return await ksgVmpCategoryRepository.GetTablesDataAsync(
            ksgKpgUid: request.KsgKpgUid,
            targetDb: request.TargetDb);
    }
}
