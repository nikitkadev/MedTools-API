using MediatR;
using Core.Common.Results;
using Core.Interfaces.Repositories.RControl;

namespace Application.Queries.RContol.ClinicalGroups.GetTreatmentComplexityCoefficientsQuery;

public class GetTreatmentComplexityCoefficientsQueryHandler(
    IClinicalGroupRepository clinicalGroupRepository) : IRequestHandler<GetTreatmentComplexityCoefficientsQuery, Result<GetTreatmentComplexityCoefficientsResult>>
{
    public async Task<Result<GetTreatmentComplexityCoefficientsResult>> Handle(
        GetTreatmentComplexityCoefficientsQuery request, 
        CancellationToken cancellationToken)
    {
        var treatmentComplexityCoefficients = await clinicalGroupRepository.GetTreatmentComplexityCoefficientsAsync(
            clinicalGroupUid: request.ClinicalGroupUid,
            targetDb: request.TargetDb,
            cancellationToken: cancellationToken);

        return Result<GetTreatmentComplexityCoefficientsResult>.Success(
            new GetTreatmentComplexityCoefficientsResult(
                TreatmentComplexityCoefficients: treatmentComplexityCoefficients));
    }
}
