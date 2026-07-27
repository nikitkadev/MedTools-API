using MediatR;

using Core.Dtos;
using Core.Common;
using Core.Interfaces.Repositories;

namespace Application.Commands.RContol.GetInvoiceSummaryCommand;

public class GetInvoiceSummaryCommandHandler(
    IInvoiceSummaryRepository invoiceSummaryRepository) : IRequestHandler<GetInvoiceSummaryCommand, Result<InvoiceSummaryQueryResult>>
{
    public async Task<Result<InvoiceSummaryQueryResult>> Handle(
        GetInvoiceSummaryCommand request, 
        CancellationToken cancellationToken)
    {
        return await invoiceSummaryRepository.GetFromStoredProcedureAsync(
            schetUid: request.SchetUid,
            targetDb: request.TargetDb);
    }
}
