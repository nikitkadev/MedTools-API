using MediatR;
using Core.Common.Results;
using Core.Common.Enums;

namespace Application.Queries.RContol.MedicalCases.GetHighTechMedicalCareQuery;

public sealed record GetHighTechMedicalCareQuery(
    int MedicalCaseUid,
    TargetDbType TargetDb) : IRequest<Result<GetHighTechMedicalCareResult>>;
