using MediatR;

namespace AFO.Application.Features.ServiceContents.Commands.DeleteServiceContent
{
    public class DeleteServiceContentCommand(Guid id) : IRequest<bool>
    {
        public Guid Id { get; init; } = id;
    }
}
