using MediatR;

using Core.Common;
using Core.Enums;

namespace Application.Queries.RContol.Oncology.GetContraindicationsQuery;

public sealed record GetContraindicationsQuery(
    int OncologyCaseUid,
    TargetDbType TargetDb) : IRequest<Result<GetContraindicationsResult>>;
