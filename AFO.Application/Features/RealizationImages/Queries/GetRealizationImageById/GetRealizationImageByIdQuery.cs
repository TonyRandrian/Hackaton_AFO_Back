
using AFO.Application.Features.RealizationImages.Responses;
using MediatR;

namespace AFO.Application.Features.RealizationImages.Queries.GetRealizationImageById
{
    public class GetRealizationImageByIdQuery(Guid id): IRequest<RealizationImageResponse?>
    {
        public Guid Id { get; init; } = id;
    }
}
