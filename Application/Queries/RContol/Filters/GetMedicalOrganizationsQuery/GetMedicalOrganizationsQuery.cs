using MediatR;

using Core.Enums;
using Core.Common;


namespace Application.Queries.RContol.Filters.GetMedicalOrganizationsQuery;

public sealed record GetMedicalOrganizationsQuery(TargetDbType TargetDb) : IRequest<Result<GetMedicalOrganizationsResult>>;
