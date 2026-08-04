using MediatR;

using Core.Common;
using Core.Dtos.Categories.DefectsSanks;
using Core.Interfaces.Repositories.Categories;

namespace Application.Queries.RContol.Categories.DefectsSanks.GetSanksDataCommand;

public class GetSanksDataCommandHandler(
    IDefectsSanksCategoryRepository defectsSanksCategoryRepository) : IRequestHandler<GetSanksDataCommand, Result<SanksQueryResult>>
{
    public async Task<Result<SanksQueryResult>> Handle(
        GetSanksDataCommand request, 
        CancellationToken cancellationToken)
    {
        return await defectsSanksCategoryRepository.GetSanksAsync(
            sluchUid: request.SluchUid,
            targetDb: request.TargetDb);
    }
}
