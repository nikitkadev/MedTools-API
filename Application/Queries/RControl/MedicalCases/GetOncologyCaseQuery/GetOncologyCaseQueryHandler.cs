using MediatR;

using Core.Common.Results;
using Core.Interfaces.Repositories.RControl;

namespace Application.Queries.RControl.MedicalCases.GetOncologyCaseQuery;

public sealed class GetOncologyCaseQueryHandler(
    IMedicalCaseRepository medicalCaseRepository) : IRequestHandler<GetOncologyCaseQuery, Result<GetOncologyCaseResult>>
{
    public async Task<Result<GetOncologyCaseResult>> Handle(
        GetOncologyCaseQuery request, 
        CancellationToken cancellationToken)
    {

        var oncologyCase = await medicalCaseRepository.GetOncologyCaseAsync(
            medicalCaseUid: request.MedicalCaseUid,
            targetDb: request.TargetDb,
            cancellationToken: cancellationToken);

        return Result<GetOncologyCaseResult>.Success(
            new GetOncologyCaseResult(
                OncologyCase: oncologyCase));

    }
}
