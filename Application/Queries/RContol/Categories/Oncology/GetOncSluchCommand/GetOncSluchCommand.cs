using MediatR;

using Core.Enums;
using Core.Common;
using Core.Dtos.RControl.Categories.Oncology;

namespace Application.Queries.RContol.Categories.Oncology.GetOncSluchCommand;

public record GetOncSluchCommand(
    int SluchUid,
    TargetDbType TargetDb) : IRequest<Result<OncSluchQueryResult>>;
