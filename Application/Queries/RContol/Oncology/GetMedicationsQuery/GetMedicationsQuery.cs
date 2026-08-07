using MediatR;

using Core.Enums;
using Core.Common;

namespace Application.Queries.RContol.Oncology.GetMedicationsQuery;

public sealed record GetMedicationsQuery(
    int OncologyServiceUid,
    TargetDbType TargetDb) : IRequest<Result<GetMedicationsResult>>;
