using MediatR;

using Core.Common;
using Core.Dtos;
using Core.Interfaces.Repositories;

namespace Application.Commands.RContol.GetOrganizationsCommand;

public class GetOrganizationsCommandHandler(
    IMedOrganizationsQueryRepository medOrganizationsQueryRepository
    ) : IRequestHandler<GetOrganizationsCommand, Result<MedOrganizationsQueryResult>>
{
    public async Task<Result<MedOrganizationsQueryResult>> Handle(GetOrganizationsCommand request, CancellationToken cancellationToken)
    {
        return await medOrganizationsQueryRepository.GetFromStoredProcedureAsync(request.TargetDb);
    }
}
