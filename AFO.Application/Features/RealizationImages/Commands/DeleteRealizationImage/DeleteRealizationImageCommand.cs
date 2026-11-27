
using MediatR;

namespace AFO.Application.Features.RealizationImages.Commands.DeleteRealizationImage
{
    public class DeleteRealizationImageCommand(Guid id) : IRequest<bool>
    {
        public Guid Id { get; init; } = id;
    }
}
