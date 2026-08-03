using MediatR;

using Core.Dtos;
using Core.Common;
using Core.Interfaces.Repositories.Categories;

namespace Application.Commands.RContol.Categories.GetPatientSmoDataCommand;

public class GetPatientSmoDataCommandHandler(
    IPatientSmoCategoryRepository patientSmoCategoryRepository) : IRequestHandler<GetPatientSmoDataCommand, Result<PatientSmoQueryResult>>
{
    public async Task<Result<PatientSmoQueryResult>> Handle(
        GetPatientSmoDataCommand request, 
        CancellationToken cancellationToken)
    {
        return await patientSmoCategoryRepository.GetFromStoredProcedureAsync(
            sluchUid: request.SluchUid, 
            targetDb: request.TargetDb);
    }
}
