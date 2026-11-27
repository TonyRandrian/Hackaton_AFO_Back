
using MediatR;

namespace AFO.Application.Features.RealizationImages.Commands.UpdateRealizationImage
{
    public class UpdateRealizationImageCommand(
        Guid id,
        string url,
        Guid realizationImageTypeId)
        : IRequest<bool>
    {
        public Guid Id { get; init; } = id;

        public string Url { get; init; } = url;

        public Guid RealizationImageTypeId { get; init; } = realizationImageTypeId;
    }
}
