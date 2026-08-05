using MediatR;

using Core.Common;
using Core.Interfaces.Repositories.Categories;
using Core.Dtos.RControl.Categories.Oncology;

namespace Application.Queries.RContol.Categories.Oncology.GetInjectionsCommand;

public class GetInjectionsCommandHandler(
    IOncologyCategoryRepository oncologyCategoryRepository) : IRequestHandler<GetInjectionsCommand, Result<InjectionsQueryResult>>
{
    public async Task<Result<InjectionsQueryResult>> Handle(
        GetInjectionsCommand request, 
        CancellationToken cancellationToken)
    {
        return await oncologyCategoryRepository.GetInjectionDataFromStoredProcedureAsync(
            medicamentUid: request.MedicamentUid,
            targetDb: request.TargetDb);
    }
}
