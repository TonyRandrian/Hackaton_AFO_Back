
using MediatR;

namespace AFO.Application.Features.RealizationImages.Commands.CreateRealizationImage
{
    public class CreateRealizationImageCommand(Guid realizationId,string url, Guid realizationImageTypeId)
        : IRequest<Guid?>
    {
        public Guid RealizationId { get; init; } = realizationId;
        public string Url { get; init; } = url;
        public Guid RealizationImageTypeId { get; init; } = realizationImageTypeId;
    }
}
