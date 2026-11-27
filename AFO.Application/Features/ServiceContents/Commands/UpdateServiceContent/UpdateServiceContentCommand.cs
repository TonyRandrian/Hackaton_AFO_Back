using MediatR;

namespace AFO.Application.Features.ServiceContents.Commands.UpdateServiceContent
{
    public class UpdateServiceContentCommand(Guid id, string name)
        : IRequest<bool>
    {
        public Guid Id { get; init; } = id;
        public string Name { get; init; } = name;
    }
}
