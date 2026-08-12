using MediatR;

using Core.Common.Results;
using Core.Common.Enums;

namespace Application.Queries.RControl.Lookups.GetMedicalOrganizationsQuery;

public sealed record GetMedicalOrganizationsQuery(TargetDbType TargetDb) : IRequest<Result<GetMedicalOrganizationsResult>>;
