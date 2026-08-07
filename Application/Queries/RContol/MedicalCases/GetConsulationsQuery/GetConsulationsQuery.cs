using MediatR;

using Core.Enums;
using Core.Common;

namespace Application.Queries.RContol.MedicalCases.GetConsulationsQuery;

public sealed record GetConsulationsQuery(
    int MedicalCaseUid,
    TargetDbType TargetDb) : IRequest<Result<GetConsulationsResult>>;
