using MediatR;

using Core.Common;
using Core.Enums;
using Core.Dtos.Categories.Oncology;

namespace Application.Queries.RContol.Categories.Oncology.GetInjectionsCommand;

public record GetInjectionsCommand(
    int MedicamentUid,
    TargetDbType TargetDb) : IRequest<Result<InjectionsQueryResult>>;
