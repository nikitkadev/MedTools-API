using MediatR;

using Core.Common.Results;
using Core.Interfaces.Repositories.RControl;

namespace Application.Queries.RContol.OncologyCases.GetContraindicationsQuery;

public class GetContraindicationsQueryHandler(
    IOncologyCaseRepository oncologyCaseRepository) : IRequestHandler<GetContraindicationsQuery, Result<GetContraindicationsResult>>
{
    public async Task<Result<GetContraindicationsResult>> Handle(
        GetContraindicationsQuery request, 
        CancellationToken cancellationToken)
    {
        var contraindications = await oncologyCaseRepository.GetContraindicationsAsync(
            oncologyCaseUid: request.OncologyCaseUid,
            targetDb: request.TargetDb,
            cancellationToken: cancellationToken);

        return Result<GetContraindicationsResult>.Success(
            new GetContraindicationsResult(
                Contraindications: contraindications));
    }
}
