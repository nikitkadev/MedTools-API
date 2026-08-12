using MediatR;

using Core.Common.Results;
using Core.Common.Enums;

namespace Application.Queries.RControl.MedicalCases.GetConsultationsQuery;

public sealed record GetConsultationsQuery(
    int MedicalCaseUid,
    TargetDbType TargetDb) : IRequest<Result<GetConsultationsResult>>;
