using MediatR;

using Core.Enums;
using Core.Common;

namespace Application.Queries.RContol.Oncology.GetInjectionsQuery;

public sealed record GetInjectionsQuery(
    int MedicationUid,
    TargetDbType TargetDb) : IRequest<Result<GetInjectionsResult>>;
