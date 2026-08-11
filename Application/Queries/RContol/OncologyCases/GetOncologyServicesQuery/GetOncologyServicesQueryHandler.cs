using MediatR;

using Core.Common.Results;
using Core.Interfaces.Repositories.RControl;

namespace Application.Queries.RContol.OncologyCases.GetOncologyServicesQuery;

public class GetOncologyServicesQueryHandler(
    IOncologyCaseRepository oncologyCaseRepository) : IRequestHandler<GetOncologyServicesQuery, Result<GetOncologyServicesResult>>
{
    public async Task<Result<GetOncologyServicesResult>> Handle(
        GetOncologyServicesQuery request, 
        CancellationToken cancellationToken)
    {
        var oncologyServices = await oncologyCaseRepository.GetOncologyServicesAsync(
            oncologyCaseUid: request.OncologyCaseUid,
            targetDb: request.TargetDb,
            cancellationToken: cancellationToken);

        return Result<GetOncologyServicesResult>.Success(
            new GetOncologyServicesResult(
                OncologyServices: oncologyServices));
    }
}
