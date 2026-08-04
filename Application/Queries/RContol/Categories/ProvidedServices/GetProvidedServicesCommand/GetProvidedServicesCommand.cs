using MediatR;

using Core.Enums;
using Core.Common;
using Core.Dtos.Categories.ProvidedServices;

namespace Application.Queries.RContol.Categories.ProvidedServices.GetProvidedServicesCommand;

public record GetProvidedServicesCommand(
    int SluchUid,
    TargetDbType TargetDb) : IRequest<Result<ProvidedServicesQueryResult>>;
