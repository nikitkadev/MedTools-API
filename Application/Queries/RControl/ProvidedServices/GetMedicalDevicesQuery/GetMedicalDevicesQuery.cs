using MediatR;

using Core.Common.Results;
using Core.Common.Enums;

namespace Application.Queries.RControl.ProvidedServices.GetMedicalDevicesQuery;

public sealed record GetMedicalDevicesQuery(
    int ProvidedServiceUid,
    TargetDbType TargetDb) : IRequest<Result<GetMedicalDevicesResult>>;
