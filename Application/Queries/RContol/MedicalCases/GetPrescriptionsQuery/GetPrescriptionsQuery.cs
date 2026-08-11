using MediatR;

using Core.Enums;
using Core.Common;

namespace Application.Queries.RContol.MedicalCases.GetPrescriptionsQuery;

public sealed record GetPrescriptionsQuery(
    int MedicalCaseUid,
    TargetDbType TargetDb) : IRequest<Result<GetPrescriptionsResult>>;
