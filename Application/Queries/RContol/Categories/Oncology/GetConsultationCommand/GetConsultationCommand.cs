using MediatR;

using Core.Enums;
using Core.Common;
using Core.Dtos.RControl.Categories.Oncology;

namespace Application.Queries.RContol.Categories.Oncology.GetConsultationCommand;

public record GetConsultationCommand(
    int SluchUid,
    TargetDbType TargetDb) : IRequest<Result<ConsultationsQueryResult>>;
