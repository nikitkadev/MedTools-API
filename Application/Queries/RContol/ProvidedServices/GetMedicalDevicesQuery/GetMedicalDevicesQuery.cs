using MediatR;

using Core.Enums;
using Core.Common;

namespace Application.Queries.RContol.ProvidedServices.GetMedicalDevicesQuery;

public sealed record GetMedicalDevicesQuery(
    int ProvidedServiceUid,
    TargetDbType TargetDb) : IRequest<Result<GetMedicalDevicesResult>>;
