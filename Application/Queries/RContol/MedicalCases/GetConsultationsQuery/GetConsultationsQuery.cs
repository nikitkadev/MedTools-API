using MediatR;

using Core.Enums;
using Core.Common;

namespace Application.Queries.RContol.MedicalCases.GetConsultationsQuery;

public sealed record GetConsultationsQuery(
    int MedicalCaseUid,
    TargetDbType TargetDb) : IRequest<Result<GetConsultationsResult>>;
