using MediatR;
using Core.Common.Results;
using Core.Common.Enums;

namespace Application.Queries.RContol.MedicalCases.GetPrescriptionsQuery;

public sealed record GetPrescriptionsQuery(
    int MedicalCaseUid,
    TargetDbType TargetDb) : IRequest<Result<GetPrescriptionsResult>>;
