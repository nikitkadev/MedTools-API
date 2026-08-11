using MediatR;
using Core.Common.Results;
using Core.Common.Enums;

namespace Application.Queries.RContol.Medications.GetInjectionDatesQuery;

public sealed record GetInjectionDatesQuery(
    int MedicationUid,
    TargetDbType TargetDb) : IRequest<Result<GetInjectionDatesResult>>;
