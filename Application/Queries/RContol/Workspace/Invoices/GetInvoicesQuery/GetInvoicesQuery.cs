using MediatR;

using Core.Enums;
using Core.Common;

namespace Application.Queries.RContol.Workspace.Invoices.GetInvoicesQuery;

public sealed record GetInvoicesQuery(
    string MedicalOrganizationCode,
    int BillingYear,
    int BillingMonth,
    int Page,
    int PageSize,
    TargetDbType TargetDb) : IRequest<Result<GetInvoicesResult>>;
