using MediatR;

using Core.Common;
using Core.Interfaces.RControl.Repositories.Oncology;

namespace Application.Queries.RContol.Oncology.GetOncologyServicesQuery;

public class GetOncologyServicesQueryHandler(
    IOncologyRepository oncologyRepository) : IRequestHandler<GetOncologyServicesQuery, Result<GetOncologyServicesResult>>
{
    public async Task<Result<GetOncologyServicesResult>> Handle(
        GetOncologyServicesQuery request, 
        CancellationToken cancellationToken)
    {
        var oncologyServices = await oncologyRepository.GetOncologyServicesAsync(
            oncologyCaseUid: request.OncologyCaseUid,
            targetDb: request.TargetDb,
            cancellationToken: cancellationToken);

        return Result<GetOncologyServicesResult>.Success(
            new GetOncologyServicesResult(
                OncologyServices: oncologyServices));
    }
}
