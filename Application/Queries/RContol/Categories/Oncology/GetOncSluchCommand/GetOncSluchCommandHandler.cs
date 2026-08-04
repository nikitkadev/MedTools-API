using MediatR;

using Core.Common;
using Core.Interfaces.Repositories.Categories;
using Core.Dtos.Categories.Oncology;

namespace Application.Queries.RContol.Categories.Oncology.GetOncSluchCommand;

public class GetOncSluchCommandHandler(
    IOncologyCategoryRepository onkologyCategoryRepository) : IRequestHandler<GetOncSluchCommand, Result<OncSluchQueryResult>>
{
    public async Task<Result<OncSluchQueryResult>> Handle(
        GetOncSluchCommand request, 
        CancellationToken cancellationToken)
    {
        return await onkologyCategoryRepository.GetOnkologyCaseFromStoredProcedureAsync(
            sluchUid: request.SluchUid,
            targetDb: request.TargetDb);
    }
}
