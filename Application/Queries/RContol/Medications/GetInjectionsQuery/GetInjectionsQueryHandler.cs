using MediatR;

using Core.Common.Results;
using Core.Interfaces.Repositories.RControl;

namespace Application.Queries.RContol.Medications.GetInjectionsQuery;

public class GetInjectionsQueryHandler(
    IMedicationRepository medicationRepository) : IRequestHandler<GetInjectionsQuery, Result<GetInjectionsResult>>
{
    public async Task<Result<GetInjectionsResult>> Handle(
        GetInjectionsQuery request, 
        CancellationToken cancellationToken)
    {
        var injections = await medicationRepository.GetInjectionsAsync(
            medicationUid: request.MedicationUid,
            targetDb: request.TargetDb,
            cancellationToken: cancellationToken);

        return Result<GetInjectionsResult>.Success(
            new GetInjectionsResult(
                Injections: injections)); 
    }
}