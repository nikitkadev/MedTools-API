using MediatR;

using Core.Common;
using Core.Enums;
using Core.Dtos.Categories.Oncology;

namespace Application.Queries.RContol.Categories.Oncology.GetMedicamentsCommand;

public record GetMedicamentsCommand(
    int OncServiceUid,
    TargetDbType TargetDb) : IRequest<Result<MedicamentsQueryResult>>;
