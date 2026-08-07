using MediatR;

using Core.Common;
using Core.Interfaces.RControl.Repositories.Oncology;

namespace Application.Queries.RContol.Oncology.GetContraindicationsQuery;

public class GetContraindicationsQueryHandler(
    IOncologyRepository oncologyRepository) : IRequestHandler<GetContraindicationsQuery, Result<GetContraindicationsResult>>
{
    public async Task<Result<GetContraindicationsResult>> Handle(
        GetContraindicationsQuery request, 
        CancellationToken cancellationToken)
    {
        var contraindications = await oncologyRepository.GetContraindicationsAsync(
            oncologyCaseUid: request.OncologyCaseUid,
            targetDb: request.TargetDb,
            cancellationToken: cancellationToken);

        return Result<GetContraindicationsResult>.Success(
            new GetContraindicationsResult(
                Contraindications: contraindications));
    }
}
