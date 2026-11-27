using MediatR;

namespace AFO.Application.Features.Services.Commands.DeleteService
{
    public class DeleteServiceCommand(Guid id) : IRequest<bool>
    {
        public Guid Id { get; init; } = id;
    }
}
