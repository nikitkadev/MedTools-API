using MediatR;

using Core.Dtos;
using Core.Enums;
using Core.Common;

namespace Application.Queries.RContol.Categories.GetPatientSmoDataCommand;

public record GetPatientSmoDataCommand(
    int SluchUid,
    TargetDbType TargetDb) : IRequest<Result<PatientSmoQueryResult>>;
