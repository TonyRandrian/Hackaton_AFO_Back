
using AFO.Application.Interfaces;
using MediatR;

namespace AFO.Application.Features.Advantages.Commands.UpdateAdvantage;

public class UpdateAdvantageCommandHandler( IAdvantageRepository repository)
    : IRequestHandler<UpdateAdvantageCommand, bool>
{
    public async Task<bool> Handle(  UpdateAdvantageCommand request,CancellationToken cancellationToken)
    {
        var advantage = await repository.GetByIdAsync(request.Id);

        if (advantage is null)
            return false;

        advantage.Update(
            request.Name,
            request.Description
        );

        await repository.UpdateAsync(advantage);

        return true;
    }
}
