using MediatR;

using Core.Common;
using Core.Interfaces.RControl.Repositories.Oncology;

namespace Application.Queries.RContol.Oncology.GetInjectionsQuery;

public class GetInjectionsQueryHandler(
    IOncologyRepository oncologyRepository) : IRequestHandler<GetInjectionsQuery, Result<GetInjectionsResult>>
{
    public async Task<Result<GetInjectionsResult>> Handle(
        GetInjectionsQuery request, 
        CancellationToken cancellationToken)
    {
        var injections = await oncologyRepository.GetInjectionsAsync(
            medicationUid: request.MedicationUid,
            targetDb: request.TargetDb,
            cancellationToken: cancellationToken);

        return Result<GetInjectionsResult>.Success(
            new GetInjectionsResult(
                Injections: injections)); 
    }
}