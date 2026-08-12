using MediatR;

using Core.Common.Results;
using Core.Common.Enums;

namespace Application.Queries.RControl.OncologyCases.GetContraindicationsQuery;

public sealed record GetContraindicationsQuery(
    int OncologyCaseUid,
    TargetDbType TargetDb) : IRequest<Result<GetContraindicationsResult>>;
