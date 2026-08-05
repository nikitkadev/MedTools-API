using MediatR;

using Core.Enums;
using Core.Common;
using Core.Dtos.RControl.Categories.KsgVmp;

namespace Application.Queries.RContol.Categories.KsgVmp.GetKsgVmpCardsDataCommand;

public record GetKsgVmpCardsDataCommand(
    int SluchUid,
    TargetDbType TargetDb) : IRequest<Result<KsgVmpCardsDataQueryResult>>;
