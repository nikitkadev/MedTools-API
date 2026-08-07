using MediatR;

using Core.Common;
using Core.Interfaces.RControl.Repositories.Oncology;

namespace Application.Queries.RContol.Oncology.GetDignosticsQuery;

public class GetDignosticsQueryHandler(
    IOncologyRepository oncologyRepository) : IRequestHandler<GetDignosticsQuery, Result<GetDignosticsResult>>
{
    public async Task<Result<GetDignosticsResult>> Handle(
        GetDignosticsQuery request, 
        CancellationToken cancellationToken)
    {
        var diagnosticsRecords = await oncologyRepository.GetDiagnosticsAsync(
            oncologyCaseUid: request.OncologyCaseUid,
            targetDb: request.TargetDb,
            cancellationToken: cancellationToken);

        return Result<GetDignosticsResult>.Success(
            new GetDignosticsResult(
                Diagnostics: diagnosticsRecords));
    }
}
