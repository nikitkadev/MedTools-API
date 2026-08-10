using MediatR;

using Core.Enums;
using Core.Common;

namespace Application.Queries.RContol.MedicalCases.GetHighTechMedicalCareQuery;

public sealed record GetHighTechMedicalCareQuery(
    int MedicalCaseUid,
    TargetDbType TargetDb) : IRequest<Result<GetHighTechMedicalCareResult>>;
