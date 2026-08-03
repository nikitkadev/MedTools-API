using MediatR;

using Core.Enums;
using Core.Common;
using Core.Dtos.Categories.Oncology;

namespace Application.Commands.RContol.Categories.Oncology.GetDetailedOncSluchCommand;

public record GetDetailedOncSluchCommand(
    int OncSluchUid,
    TargetDbType TargetDb) : IRequest<Result<DetailedOncSluchQueryResult>>;
