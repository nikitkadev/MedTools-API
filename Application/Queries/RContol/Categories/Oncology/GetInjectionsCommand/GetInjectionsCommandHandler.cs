using MediatR;

using Core.Common;
using Core.Dtos.Categories.Oncology;
using Core.Interfaces.Repositories.Categories;

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
