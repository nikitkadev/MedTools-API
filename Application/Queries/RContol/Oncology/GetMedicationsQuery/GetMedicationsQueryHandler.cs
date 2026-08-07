using MediatR;

using Core.Common;
using Core.Interfaces.RControl.Repositories.Oncology;

namespace Application.Queries.RContol.Oncology.GetMedicationsQuery;

public class GetMedicationsQueryHandler(
    IOncologyRepository oncologyRepository) : IRequestHandler<GetMedicationsQuery, Result<GetMedicationsResult>>
{
    public async Task<Result<GetMedicationsResult>> Handle(
        GetMedicationsQuery request,
        CancellationToken cancellationToken)
    {
        var medications = await oncologyRepository.GetMedicationsAsync(
            oncologyServiceUid: request.OncologyServiceUid,
            targetDb: request.TargetDb,
            cancellationToken: cancellationToken);

        return Result<GetMedicationsResult>.Success(
            new GetMedicationsResult(
                Medications: medications));
    }
}
