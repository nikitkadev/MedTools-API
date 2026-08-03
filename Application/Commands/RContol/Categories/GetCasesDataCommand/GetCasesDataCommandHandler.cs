using MediatR;

using Core.Common;
using Core.Dtos;
using Core.Interfaces.Repositories.Categories;

namespace Application.Commands.RContol.Categories.GetCasesDataCommand;

public class GetCasesDataCommandHandler(
    ICasesCategoryRepository casesCategoryRepository) : IRequestHandler<GetCasesDataCommand, Result<CategoryCasesQueryResult>>
{
    public async Task<Result<CategoryCasesQueryResult>> Handle(
        GetCasesDataCommand request, 
        CancellationToken cancellationToken)
    {
        return await casesCategoryRepository.GetFromStoredProcedureAsync(
            sluchUid: request.SluchUid,
            targetDb: request.TargetDb);
    }
}
