using MediatR;

using Core.Common.Results;
using Core.Common.Enums;

namespace Application.Queries.RControl.Invoices.GetInvoiceSummaryQuery;

public sealed record GetInvoiceSummaryQuery(
    int InvoiceUid,
    TargetDbType TargetDb) : IRequest<Result<GetInvoiceSummaryResult>>;
