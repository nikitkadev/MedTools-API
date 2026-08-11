using MediatR;
using Core.Common.Results;
using Core.Common.Enums;

namespace Application.Queries.RContol.OncologyCases.GetOncologyServicesQuery;

public sealed record GetOncologyServicesQuery(
    int OncologyCaseUid,
    TargetDbType TargetDb) : IRequest<Result<GetOncologyServicesResult>>;
