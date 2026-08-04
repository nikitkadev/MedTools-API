using MediatR;

using Core.Dtos;
using Core.Common;
using Core.Interfaces.Repositories.MainField;

namespace Application.Queries.RContol.General.GetInvoicesShortlyCommand;

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
            page: request.Page,
            pageSize: request.PageSize,
            searchString: request.SearchString);
    }
}
