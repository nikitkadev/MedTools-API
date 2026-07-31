using MediatR;

using Core.Common;
using Core.Dtos.Categories.KsgVmp;
using Core.Enums;

namespace Application.Commands.RContol.Categories.KsgVmp.GetKsgVmpTablesDataCommand;

public record GetKsgVmpTablesDataCommand(
    int KsgKpgUid,
    TargetDbType TargetDb) : IRequest<Result<KsgVmpTablesQueryResult>>;
