using MediatR;

using Core.Common;
using Core.Dtos.Categories.NazNapr;
using Core.Interfaces.Repositories.Categories;

namespace Application.Queries.RContol.Categories.NazNapr.GetNazNaprDataCommand;

public class GetNazNaprDataCommandHandler(
    INazNaprCategoryRepository nazNaprCategoryRepository) : IRequestHandler<GetNazNaprDataCommand, Result<NazNaprQueryResult>>
{
    public async Task<Result<NazNaprQueryResult>> Handle(
        GetNazNaprDataCommand request, 
        CancellationToken cancellationToken)
    {
        return await nazNaprCategoryRepository.GetDataAsync(
            sluchUid: request.SluchUid,
            targetDb: request.TargetDb);
    }
}