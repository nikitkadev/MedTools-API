using MediatR;

using Core.Common.Enums;
using Core.Common.Results;

namespace Application.Queries.MedView.Filters.GetMedicalOrganizationFilterOptionsQuery;

public sealed record GetMedicalOrganizationFilterOptionsQuery(
    TargetDbType TargetDb,
    MedicalOrgsKeysFrom MedicalOrgsKeysFrom) : IRequest<Result<GetMedicalOrganizationFilterOptionsResult>>;
