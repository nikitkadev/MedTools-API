using MediatR;

using Core.Common;
using Core.Interfaces.RControl.Repositories.Oncology;

namespace Application.Queries.RContol.Oncology.GetOncologyCaseQuery;

public class GetOncologyCaseQueryHandler(
    IOncologyRepository oncologyRepository) : IRequestHandler<GetOncologyCaseQuery, Result<GetOncologyCaseResult>>
{
    public async Task<Result<GetOncologyCaseResult>> Handle(
        GetOncologyCaseQuery request, 
        CancellationToken cancellationToken)
    {

        var oncologyCase = await oncologyRepository.GetOncologyCaseAsync(
            medicalCaseUid: request.MedicalCaseUid,
            targetDb: request.TargetDb,
            cancellationToken: cancellationToken);

        if(oncologyCase is null)
        {
            return Result<GetOncologyCaseResult>.Failure("Данных по онкологическому случаю не найдено");
        }

        return Result<GetOncologyCaseResult>.Success(
            new GetOncologyCaseResult(
                OncologyCase: oncologyCase));

    }
}
