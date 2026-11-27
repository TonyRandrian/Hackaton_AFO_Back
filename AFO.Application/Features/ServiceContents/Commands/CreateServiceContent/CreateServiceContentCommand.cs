using MediatR;

namespace AFO.Application.Features.ServiceContents.Commands.CreateServiceContent
{
    public class CreateServiceContentCommand(Guid serviceId, string name)
        : IRequest<Guid?>
    {
        public Guid ServiceId { get; init; } = serviceId;
        public string Name { get; init; } = name;
    }
}
