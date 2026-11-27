
using AFO.Application.Interfaces;
using MediatR;

namespace AFO.Application.Features.Advantages.Commands.DeleteAdvantage;

public class DeleteAdvantageCommandHandler(IAdvantageRepository repository)
    : IRequestHandler<DeleteAdvantageCommand, bool>
{
    public async Task<bool> Handle(  DeleteAdvantageCommand request, CancellationToken cancellationToken)
    {
        var advantage = await repository.GetByIdAsync(request.Id);

        if (advantage is null)
            return false;

        if (await repository.IsUsedAsync(request.Id))
            throw new InvalidOperationException(
                "Cet avantage est utilisé par une ou plusieurs réalisations."
            );

        await repository.DeleteAsync(advantage);

        return true;
    }
}
