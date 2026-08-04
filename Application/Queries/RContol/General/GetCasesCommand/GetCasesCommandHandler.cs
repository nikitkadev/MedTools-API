using MediatR;

using Core.Common;
using Core.Dtos;
using Core.Interfaces.Repositories.MainField;

namespace Application.Queries.RContol.General.GetCasesCommand;

public class GetCasesCommandHandler(
    ICasesRepository casesRepository) : IRequestHandler<GetCasesCommand, Result<CasesQueryResult>>
{
    public async Task<Result<CasesQueryResult>> Handle(
        GetCasesCommand request, 
        CancellationToken cancellationToken)
    {
        return await casesRepository.GetFromStorageProcedureAsync(
            zSlUid: request.ZSlUid,
            targetDb: request.TargetDb);
    }
}
