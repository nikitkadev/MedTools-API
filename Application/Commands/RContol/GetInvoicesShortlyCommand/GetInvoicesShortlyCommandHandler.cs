using MediatR;

using Core.Dtos;
using Core.Common;
using Core.Interfaces.Repositories;

namespace Application.Commands.RContol.GetInvoicesShortlyCommand;

public class GetInvoicesShortlyCommandHandler(
    IInvoiceQueryRepository invoiceQueryRepository) : IRequestHandler<GetInvoicesShortlyCommand, Result<InvoicesShortlyQueryResult>>
{
    public async Task<Result<InvoicesShortlyQueryResult>> Handle(
        GetInvoicesShortlyCommand request, 
        CancellationToken cancellationToken)
    {
        return await invoiceQueryRepository.GetShortlyAsync(
            orgCode: request.OrgCode,
            year: request.Year,
            month: request.Month,
            dbType: request.TargetDb,
            skip: request.Skip,
            take: request.Take,
            searchString: request.SearchString);
    }
}
