using MediatR;

using Core.Enums;
using Core.Common;
using Core.Dtos.RControl.Categories.NazNapr;

namespace Application.Queries.RContol.Categories.NazNapr.GetNazNaprDataCommand;

public record GetNazNaprDataCommand(
    int SluchUid,
    TargetDbType TargetDb) : IRequest<Result<NazNaprQueryResult>>;
