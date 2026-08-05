using MediatR;

using Core.Common;
using Core.Interfaces.Repositories.Categories;
using Core.Dtos.RControl.Categories.Oncology;

namespace Application.Queries.RContol.Categories.Oncology.GetMedicamentsCommand;

public class GetMedicamentsCommandHandler(
    IOncologyCategoryRepository oncologyCategoryRepository) : IRequestHandler<GetMedicamentsCommand, Result<MedicamentsQueryResult>>
{
    public async Task<Result<MedicamentsQueryResult>> Handle(
        GetMedicamentsCommand request, 
        CancellationToken cancellationToken)
    {
        return await oncologyCategoryRepository.GetMedicamentsFromStoredProcedureAsync(
            oncServiceUid: request.OncServiceUid,
            targetDb: request.TargetDb);
    }
}