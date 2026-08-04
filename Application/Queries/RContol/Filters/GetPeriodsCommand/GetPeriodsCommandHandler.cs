using MediatR;

using Core.Dtos;
using Core.Common;
using Core.Interfaces.Repositories.Filters;

namespace Application.Queries.RContol.Filters.GetPeriodsCommand;

public class GetPeriodsCommandHandler(
    IBillingPeriodsQueryRepository billingPeriodsQueryRepository) : IRequestHandler<GetPeriodsCommand, Result<BillingPeriodsQueryResult>>
{
    public async Task<Result<BillingPeriodsQueryResult>> Handle(
        GetPeriodsCommand request, 
        CancellationToken cancellationToken)
    {
        return await billingPeriodsQueryRepository.GetFromStoredProcedureAsync(
            targetDbType: request.TargetDbType,
            orgCode: request.OrgCode);
    }
}
