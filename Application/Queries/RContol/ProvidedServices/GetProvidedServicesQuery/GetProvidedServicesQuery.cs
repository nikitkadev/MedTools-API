using MediatR;

using Core.Enums;
using Core.Common;

namespace Application.Queries.RContol.ProvidedServices.GetProvidedServicesQuery;

public sealed record GetProvidedServicesQuery(
    int MedicalCaseUid,
    TargetDbType TargetDb) : IRequest<Result<GetProvidedServicesResult>>;
