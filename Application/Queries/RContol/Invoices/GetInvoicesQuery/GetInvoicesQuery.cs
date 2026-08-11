using MediatR;
using Core.Common.Results;
using Core.Common.Enums;

namespace Application.Queries.RContol.Invoices.GetInvoicesQuery;

public sealed record GetInvoicesQuery(
    string MedicalOrganizationCode,
    int BillingYear,
    int BillingMonth,
    int Page,
    int PageSize,
    TargetDbType TargetDb) : IRequest<Result<GetInvoicesResult>>;
