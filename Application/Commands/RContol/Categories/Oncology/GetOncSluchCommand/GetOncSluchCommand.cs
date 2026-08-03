using MediatR;

using Core.Enums;
using Core.Common;
using Core.Dtos.Categories.Oncology;

namespace Application.Commands.RContol.Categories.Oncology.GetOncSluchCommand;

public record GetOncSluchCommand(
    int SluchUid,
    TargetDbType TargetDb) : IRequest<Result<OncSluchQueryResult>>;
