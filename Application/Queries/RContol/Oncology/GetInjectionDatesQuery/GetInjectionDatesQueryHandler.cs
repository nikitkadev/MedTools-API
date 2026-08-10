using MediatR;

using Core.Common;
using Core.Interfaces.RControl.Repositories.Oncology;

namespace Application.Queries.RContol.Oncology.GetInjectionDatesQuery;

public class GetInjectionDatesQueryHandler(
    IOncologyRepository oncologyRepository) : IRequestHandler<GetInjectionDatesQuery, Result<GetInjectionDatesResult>>
{
    public async Task<Result<GetInjectionDatesResult>> Handle(
        GetInjectionDatesQuery request, 
        CancellationToken cancellationToken)
    {
        var injectionDates = await oncologyRepository.GetInjectionDatesAsync(
            medicationUid: request.MedicationUid,
            targetDb: request.TargetDb,
            cancellationToken: cancellationToken);

        return Result<GetInjectionDatesResult>.Success(
            new GetInjectionDatesResult(
                InjectionDates: injectionDates));
    }
}
