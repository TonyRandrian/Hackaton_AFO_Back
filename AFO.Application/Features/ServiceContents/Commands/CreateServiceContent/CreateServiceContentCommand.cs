using MediatR;

namespace AFO.Application.Features.ServiceContents.Commands.CreateServiceContent
{
    public class CreateServiceContentCommand(Guid serviceId, string name, decimal price, string? description, List<string> includes)
        : IRequest<Guid?>
    {
        public Guid ServiceId { get; init; } = serviceId;
        public string Name { get; init; } = name;
        public decimal Price { get; set; } = price;
        public string? Description { get; set; } = description;
        public List<string> Includes { get; set; } = includes;
    }
}
