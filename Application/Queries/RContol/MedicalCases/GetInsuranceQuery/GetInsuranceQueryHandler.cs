using MediatR;
using Core.Common.Results;
using Core.Interfaces.Repositories.RControl;

namespace Application.Queries.RContol.MedicalCases.GetInsuranceQuery;

public class GetInsuranceQueryHandler(
    IMedicalCaseRepository medicalCaseRepository) : IRequestHandler<GetInsuranceQuery, Result<GetInsuranceResult>>
{
    public async Task<Result<GetInsuranceResult>> Handle(
        GetInsuranceQuery request, 
        CancellationToken cancellationToken)
    {
        var insurance = await medicalCaseRepository.GetInsuranceAsync(
            medicalCaseUid: request.MedicalCaseUid,
            targetDb: request.TargetDb,
            cancellationToken: cancellationToken);

        if (insurance is null)
        {
            return Result<GetInsuranceResult>.Failure("Не удалось найти данные по страховой");
        }

        return Result<GetInsuranceResult>.Success(
            new GetInsuranceResult(
                Insurance: insurance));
    }
}
