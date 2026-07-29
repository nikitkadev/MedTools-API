using MediatR;

using Core.Common;
using Core.Dtos.Categories.Onkology;
using Core.Interfaces.Repositories.Categories;

namespace Application.Commands.RContol.Categories.Onkology.GetOnkSluchCommand;

public class GetOnkSluchCommandHandler(
    IOnkologyCategoryRepository onkologyCategoryRepository) : IRequestHandler<GetOnkSluchCommand, Result<OnkSluchQueryResult>>
{
    public async Task<Result<OnkSluchQueryResult>> Handle(
        GetOnkSluchCommand request, 
        CancellationToken cancellationToken)
    {
        return await onkologyCategoryRepository.GetOnkologyCaseFromStoredProcedureAsync(
            sluchUid: request.SluchUid,
            targetDb: request.TargetDb);
    }
}
