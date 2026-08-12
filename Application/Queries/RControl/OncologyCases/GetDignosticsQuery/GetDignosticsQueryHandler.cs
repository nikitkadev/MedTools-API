using MediatR;

using Core.Common.Results;
using Core.Interfaces.Repositories.RControl;

namespace Application.Queries.RControl.OncologyCases.GetDignosticsQuery;

public class GetDignosticsQueryHandler(
    IOncologyCaseRepository oncologyCaseRepository) : IRequestHandler<GetDignosticsQuery, Result<GetDignosticsResult>>
{
    public async Task<Result<GetDignosticsResult>> Handle(
        GetDignosticsQuery request, 
        CancellationToken cancellationToken)
    {
        var diagnosticsRecords = await oncologyCaseRepository.GetDiagnosticsAsync(
            oncologyCaseUid: request.OncologyCaseUid,
            targetDb: request.TargetDb,
            cancellationToken: cancellationToken);

        return Result<GetDignosticsResult>.Success(
            new GetDignosticsResult(
                Diagnostics: diagnosticsRecords));
    }
}
