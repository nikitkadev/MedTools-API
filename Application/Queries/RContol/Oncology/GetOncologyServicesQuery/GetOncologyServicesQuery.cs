using MediatR;

using Core.Enums;
using Core.Common;

namespace Application.Queries.RContol.Oncology.GetOncologyServicesQuery;

public sealed record GetOncologyServicesQuery(
    int OncologyCaseUid,
    TargetDbType TargetDb) : IRequest<Result<GetOncologyServicesResult>>;
