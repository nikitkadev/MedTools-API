using MediatR;

using Core.Enums;
using Core.Common;
using Core.Dtos.RControl.Categories.ProvidedServices;

namespace Application.Queries.RContol.Categories.ProvidedServices.GetMedDevsCommand;

public record GetMedDevsCommand(
    int ProvidedServiceUid,
    TargetDbType TargetDb) : IRequest<Result<MedDevsQueryResult>>;
