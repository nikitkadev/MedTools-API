using MediatR;

using Core.Common.Results;
using Core.Interfaces.Repositories.RControl;

namespace Application.Queries.RContol.Medications.GetInjectionDatesQuery;

public class GetInjectionDatesQueryHandler(
    IMedicationRepository medicationRepository) : IRequestHandler<GetInjectionDatesQuery, Result<GetInjectionDatesResult>>
{
    public async Task<Result<GetInjectionDatesResult>> Handle(
        GetInjectionDatesQuery request, 
        CancellationToken cancellationToken)
    {
        var injectionDates = await medicationRepository.GetInjectionDatesAsync(
            medicationUid: request.MedicationUid,
            targetDb: request.TargetDb,
            cancellationToken: cancellationToken);

        return Result<GetInjectionDatesResult>.Success(
            new GetInjectionDatesResult(
                InjectionDates: injectionDates));
    }
}
