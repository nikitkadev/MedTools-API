using MediatR;

using Core.Common;
using Core.Enums;

namespace Application.Queries.RContol.Workspace.Invoices.GetInvoiceSummaryQuery;

public sealed record GetInvoiceSummaryQuery(
    int InvoiceUid,
    TargetDbType TargetDb) : IRequest<Result<GetInvoiceSummaryResult>>;
