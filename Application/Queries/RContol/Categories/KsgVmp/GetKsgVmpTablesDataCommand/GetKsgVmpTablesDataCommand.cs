using MediatR;

using Core.Common;
using Core.Enums;
using Core.Dtos.RControl.Categories.KsgVmp;

namespace Application.Queries.RContol.Categories.KsgVmp.GetKsgVmpTablesDataCommand;

public record GetKsgVmpTablesDataCommand(
    int KsgKpgUid,
    TargetDbType TargetDb) : IRequest<Result<KsgVmpTablesQueryResult>>;
