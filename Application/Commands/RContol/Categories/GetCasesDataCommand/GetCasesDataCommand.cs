using MediatR;

using Core.Dtos;
using Core.Enums;
using Core.Common;

namespace Application.Commands.RContol.Categories.GetCasesDataCommand;

public record GetCasesDataCommand(
    int SluchUid,
    TargetDbType TargetDb) : IRequest<Result<CategoryCasesQueryResult>>;

