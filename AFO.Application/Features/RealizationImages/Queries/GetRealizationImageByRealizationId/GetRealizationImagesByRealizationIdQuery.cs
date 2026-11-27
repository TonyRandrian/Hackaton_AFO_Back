
using AFO.Application.Features.RealizationImages.Responses;
using MediatR;

namespace AFO.Application.Features.RealizationImages.Queries.GetRealizationImagesByRealizationId
{
    public class GetRealizationImagesByRealizationIdQuery(Guid realizationId)
        : IRequest<List<RealizationImageListResponse>>
    {
        public Guid RealizationId { get; init; } = realizationId;
    }
}
