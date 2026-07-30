using MediatR;

using Core.Enums;
using Core.Common;
using Core.Dtos.Categories.ProvidedServices;

namespace Application.Commands.RContol.Categories.ProvidedServices.GetMedDevsCommand;

public record GetMedDevsCommand(
    int ProvidedServiceUid,
    TargetDbType TargetDb) : IRequest<Result<MedDevsQueryResult>>;
