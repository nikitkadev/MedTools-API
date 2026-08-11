using MediatR;

using Core.Enums;
using Core.Common;

namespace Application.Queries.RContol.MedicalCases.GetMedicalSanctionsQuery;

public sealed record GetMedicalSanctionsQuery(
    int MedicalCaseUid,
    TargetDbType TargetDb) : IRequest<Result<GetMedicalSanctionsResult>>;
