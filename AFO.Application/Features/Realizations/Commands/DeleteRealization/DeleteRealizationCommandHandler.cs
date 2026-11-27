
using AFO.Application.Interfaces;
using MediatR;
namespace AFO.Application.Features.Realizations.Commands.DeleteRealization;

public class DeleteRealizationCommandHandler(  IRealizationRepository repository)
    : IRequestHandler<DeleteRealizationCommand, bool>
{
    public async Task<bool> Handle(DeleteRealizationCommand request, CancellationToken cancellationToken)
    {
        var realization = await repository.GetByIdAsync( request.Id,  cancellationToken);
        if (realization is null)
            return false;

        await repository.DeleteAsync( realization,   cancellationToken);

        return true;
    }
}
