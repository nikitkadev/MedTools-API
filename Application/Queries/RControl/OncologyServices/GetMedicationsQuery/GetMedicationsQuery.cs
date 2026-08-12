using MediatR;

using Core.Common.Results;
using Core.Common.Enums;

namespace Application.Queries.RControl.OncologyServices.GetMedicationsQuery;

public sealed record GetMedicationsQuery(
    int OncologyServiceUid,
    TargetDbType TargetDb) : IRequest<Result<GetMedicationsResult>>;
