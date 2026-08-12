using MediatR;

using Core.Common.Results;
using Core.Interfaces.Repositories.RControl;

namespace Application.Queries.RControl.MedicalCases.GetDefectsQuery;

public sealed class GetDefectsQueryHandler(
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
