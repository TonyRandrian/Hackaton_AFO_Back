
using AFO.Application.Features.Realizations.Responses;
using AFO.Application.Interfaces;
using MediatR;
namespace AFO.Application.Features.Realizations.Queries.GetRealizations;

public class GetRealizationsQueryHandler(IRealizationRepository repository)
    : IRequestHandler<GetRealizationsQuery, List<RealizationListResponse>>
{
    public async Task<List<RealizationListResponse>> Handle( GetRealizationsQuery request,
        CancellationToken cancellationToken)
    {
        var realizations = await repository.GetAllAsync( request.PublicOnly, cancellationToken);

        return realizations.Select(r => new RealizationListResponse
        {
            Id = r.Id,
            Name = r.Name,
            ShortDescription = r.ShortDescription,
            Title = r.Title,
            IsPublic = r.IsPublic,
            ProjectUrl = r.ProjectUrl
        }).ToList();
    }
}
