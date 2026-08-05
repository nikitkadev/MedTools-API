using MediatR;

using Core.Common;
using Core.Interfaces.Repositories.Categories;
using Core.Dtos.RControl.Categories.Oncology;

namespace Application.Queries.RContol.Categories.Oncology.GetDetailedOncSluchCommand;

public class GetDetailedOncSluchCommandHandler(
    IOncologyCategoryRepository oncologyCategoryRepository) : IRequestHandler<GetDetailedOncSluchCommand, Result<DetailedOncSluchQueryResult>>
{
    public async Task<Result<DetailedOncSluchQueryResult>> Handle(
        GetDetailedOncSluchCommand request, 
        CancellationToken cancellationToken)
    {
        return await oncologyCategoryRepository.GetDetailedOncSluchFromStoredProcedureAsync(
            oncSluchUid: request.OncSluchUid,
            targetDb: request.TargetDb);
    }
}
