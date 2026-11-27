
using AFO.Application.Features.Advantages.Responses;
using AFO.Application.Interfaces;
using MediatR;

namespace AFO.Application.Features.Advantages.Queries.GetAdvantages;

public class GetAdvantagesQueryHandler(
    IAdvantageRepository repository)
    : IRequestHandler<GetAdvantagesQuery, List<AdvantageListResponse>>
{
    public async Task<List<AdvantageListResponse>> Handle( GetAdvantagesQuery request,  CancellationToken cancellationToken)
    {
        var advantages = await repository.GetAllAsync();

        return advantages.Select(a => new AdvantageListResponse(
            a.Id,
            a.Name,
            a.Description
        )).ToList();
    }
}
