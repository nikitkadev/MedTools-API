using MediatR;

using Core.Common;
using Core.Enums;

namespace Application.Queries.RContol.Oncology.GetInjectionDatesQuery;

public sealed record GetInjectionDatesQuery(
    int MedicationUid,
    TargetDbType TargetDb) : IRequest<Result<GetInjectionDatesResult>>;
