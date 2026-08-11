using MediatR;
using Core.Common.Results;
using Core.Common.Enums;

namespace Application.Queries.RContol.Medications.GetInjectionsQuery;

public sealed record GetInjectionsQuery(
    int MedicationUid,
    TargetDbType TargetDb) : IRequest<Result<GetInjectionsResult>>;
