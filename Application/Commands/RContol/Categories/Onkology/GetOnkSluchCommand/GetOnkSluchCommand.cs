using MediatR;

using Core.Enums;
using Core.Common;
using Core.Dtos.Categories.Onkology;

namespace Application.Commands.RContol.Categories.Onkology.GetOnkSluchCommand;

public record GetOnkSluchCommand(
    int SluchUid,
    TargetDbType TargetDb) : IRequest<Result<OnkSluchQueryResult>>;
