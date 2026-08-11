using MediatR;
using Core.Common.Results;
using Core.Interfaces.Repositories.RControl;

namespace Application.Queries.RContol.MedicalCases.GetReferralsQuery;

public class GetReferralsQueryHandler(
    IMedicalCaseRepository medicalCaseRepository) : IRequestHandler<GetReferralsQuery, Result<GetReferralsResult>>
{
    public async Task<Result<GetReferralsResult>> Handle(
        GetReferralsQuery request, 
        CancellationToken cancellationToken)
    {
        var referrals = await medicalCaseRepository.GetReferralsAsync(
            medicalCaseUid: request.MedicalCaseUid,
            targetDb: request.TargetDb,
            cancellationToken: cancellationToken);

        return Result<GetReferralsResult>.Success(
            new GetReferralsResult(
                Referrals: referrals));
    }
}
