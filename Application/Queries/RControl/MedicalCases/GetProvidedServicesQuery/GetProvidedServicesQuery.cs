using MediatR;

using Core.Common.Results;
using Core.Common.Enums;

namespace Application.Queries.RControl.MedicalCases.GetProvidedServicesQuery;

public sealed record GetProvidedServicesQuery(
    int MedicalCaseUid,
    TargetDbType TargetDb) : IRequest<Result<GetProvidedServicesResult>>;
