
using AFO.Application.Features.Advantages.Responses;
using AFO.Application.Interfaces;
using MediatR;

namespace AFO.Application.Features.Advantages.Queries.GetAdvantageById;

public class GetAdvantageByIdQueryHandler( IAdvantageRepository repository)
    : IRequestHandler<GetAdvantageByIdQuery, AdvantageResponse?>
{
    public async Task<AdvantageResponse?> Handle(  GetAdvantageByIdQuery request, CancellationToken cancellationToken)
    {
        var advantage = await repository.GetByIdAsync(request.Id);

        if (advantage is null)
            return null;

        return new AdvantageResponse(
            advantage.Id,
            advantage.Name,
            advantage.Description
        );
    }
}
