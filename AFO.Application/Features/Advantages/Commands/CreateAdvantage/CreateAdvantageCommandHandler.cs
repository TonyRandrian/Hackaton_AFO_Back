
using AFO.Application.Interfaces;
using AFO.Domain.Entities;
using MediatR;

namespace AFO.Application.Features.Advantages.Commands.CreateAdvantage;

public class CreateAdvantageCommandHandler( IAdvantageRepository repository)
    : IRequestHandler<CreateAdvantageCommand, Guid>
{
    public async Task<Guid> Handle( CreateAdvantageCommand request,CancellationToken cancellationToken)
    {
        Advantage advantage = new(
            request.Name,
            request.Description 
            );

        await repository.AddAsync(advantage);

        return advantage.Id;
    }
}
