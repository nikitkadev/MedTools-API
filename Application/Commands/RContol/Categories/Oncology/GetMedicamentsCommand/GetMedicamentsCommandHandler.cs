using MediatR;

using Core.Common;
using Core.Dtos.Categories.Oncology;
using Core.Interfaces.Repositories.Categories;

namespace Application.Commands.RContol.Categories.Oncology.GetMedicamentsCommand;

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