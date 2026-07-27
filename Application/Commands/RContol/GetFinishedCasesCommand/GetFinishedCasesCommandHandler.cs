using MediatR;

using Core.Dtos;
using Core.Common;
using Core.Interfaces.Repositories;

namespace Application.Commands.RContol.GetFinishedCasesCommand;

public class GetFinishedCasesCommandHandler(
    IFinishedCasesRepository finishedCasesRepository) : IRequestHandler<GetFinishedCasesCommand, Result<FinishedCasesQueryResult>>
{
    public async Task<Result<FinishedCasesQueryResult>> Handle(
        GetFinishedCasesCommand request, 
        CancellationToken cancellationToken)
    {
        return await finishedCasesRepository.GetFromStoredProcedureAsync(
            schetUid: request.SchetUid,
            dbType: request.TargetDb,
            page: request.Page,
            pageSize: request.PageSize,
            searchString: request.SearchString);
    }
}
