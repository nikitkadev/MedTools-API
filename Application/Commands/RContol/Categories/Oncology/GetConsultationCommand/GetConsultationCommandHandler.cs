using MediatR;

using Core.Common;
using Core.Interfaces.Repositories.Categories;
using Core.Dtos.Categories.Oncology;

namespace Application.Commands.RContol.Categories.Oncology.GetConsultationCommand;

public class GetConsultationCommandHandler(
    IOncologyCategoryRepository onkologyCategoryRepository) : IRequestHandler<GetConsultationCommand, Result<ConsultationsQueryResult>>
{
    public async Task<Result<ConsultationsQueryResult>> Handle(
        GetConsultationCommand request, 
        CancellationToken cancellationToken)
    {
        return await onkologyCategoryRepository.GetConsultationFromStoredProcedureAsync(
            sluchUid: request.SluchUid,
            targetDb: request.TargetDb);
    }
}
