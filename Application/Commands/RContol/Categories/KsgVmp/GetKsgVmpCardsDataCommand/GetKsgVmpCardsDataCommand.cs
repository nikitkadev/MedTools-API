using MediatR;

using Core.Enums;
using Core.Common;
using Core.Dtos.Categories.KsgVmp;

namespace Application.Commands.RContol.Categories.KsgVmp.GetKsgVmpCardsDataCommand;

public record GetKsgVmpCardsDataCommand(
    int SluchUid,
    TargetDbType TargetDb) : IRequest<Result<KsgVmpCardsDataQueryResult>>;
