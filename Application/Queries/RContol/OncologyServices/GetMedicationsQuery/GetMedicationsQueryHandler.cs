using MediatR;

using Core.Common.Results;
using Core.Interfaces.Repositories.RControl;

namespace Application.Queries.RContol.OncologyServices.GetMedicationsQuery;

public class GetMedicationsQueryHandler(
    IOncologyServiceRepository oncologyServiceRepository) : IRequestHandler<GetMedicationsQuery, Result<GetMedicationsResult>>
{
    public async Task<Result<GetMedicationsResult>> Handle(
        GetMedicationsQuery request,
        CancellationToken cancellationToken)
    {
        var medications = await oncologyServiceRepository.GetMedicationsAsync(
            oncologyServiceUid: request.OncologyServiceUid,
            targetDb: request.TargetDb,
            cancellationToken: cancellationToken);

        return Result<GetMedicationsResult>.Success(
            new GetMedicationsResult(
                Medications: medications));
    }
}
