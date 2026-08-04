using MediatR;

using Core.Enums;
using Core.Common;
using Core.Dtos.Categories.DefectsSanks;

namespace Application.Queries.RContol.Categories.DefectsSanks.GetSanksDataCommand;

public record GetSanksDataCommand(
    int SluchUid,
    TargetDbType TargetDb) : IRequest<Result<SanksQueryResult>>;
