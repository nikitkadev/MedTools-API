using MediatR;

using Core.Common;
using Core.Interfaces.RControl.Repositories.Workspace;

namespace Application.Queries.RContol.MedicalCases.GetDefectsQuery;

public class GetDefectsQueryHandler(
    IMedicalCaseRepository medicalCaseRepository) : IRequestHandler<GetDefectsQuery, Result<GetDefectsResult>>
{
    public async Task<Result<GetDefectsResult>> Handle(
        GetDefectsQuery request, 
        CancellationToken cancellationToken)
    {
        var pagedResult = await medicalCaseRepository.GetDefectsAsync(
            medicalCaseUid: request.MedicalCaseUid,
            targetDb: request.TargetDb,
            page: request.Page,
            pageSize: request.PageSize,
            cancellationToken: cancellationToken);

        return Result<GetDefectsResult>.Success(
            new GetDefectsResult(
                Defects: pagedResult.Records,
                TotalCount: pagedResult.TotalCount));
    }
}
