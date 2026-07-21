using MediatR;

using Core.Common;
using Core.Dtos;

namespace Application.Commands.RContol.GetOrganizationsCommand;

public class GetOrganizationsCommandHandler(
    ) : IRequestHandler<GetOrganizationsCommand, Result<MedOrganizationsQueryResult>>
{
    public Task<Result<MedOrganizationsQueryResult>> Handle(GetOrganizationsCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
