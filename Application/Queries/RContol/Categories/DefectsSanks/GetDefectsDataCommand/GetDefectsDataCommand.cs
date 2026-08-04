using MediatR;

using Core.Common;
using Core.Enums;
using Core.Dtos.Categories.DefectsSanks;

namespace Application.Queries.RContol.Categories.DefectsSanks.GetDefectsDataCommand;

public record GetDefectsDataCommand(
    int SluchUid,
    TargetDbType TargetDb,
    int Page,
    int PageSize) : IRequest<Result<DefectsQueryResult>>;
