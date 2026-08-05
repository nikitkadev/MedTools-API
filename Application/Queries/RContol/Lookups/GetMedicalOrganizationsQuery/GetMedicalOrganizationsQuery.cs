using MediatR;

using Core.Enums;
using Core.Common;

namespace Application.Queries.RContol.Lookups.GetMedicalOrganizationsQuery;

public sealed record GetMedicalOrganizationsQuery(TargetDbType TargetDb) : IRequest<Result<GetMedicalOrganizationsResult>>;
