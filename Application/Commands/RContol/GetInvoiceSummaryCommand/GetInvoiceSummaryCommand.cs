using MediatR;

using Core.Dtos;
using Core.Enums;
using Core.Common;

namespace Application.Commands.RContol.GetInvoiceSummaryCommand;

public record GetInvoiceSummaryCommand(
    TargetDbType TargetDb,
    int SchetUid) : IRequest<Result<InvoiceSummaryQueryResult>>;
