using MediatR;

namespace AFO.Application.Features.ServiceContents.Commands.UpdateServiceContent
{
    public class UpdateServiceContentCommand(Guid id, string name, decimal price, string? description, List<string> includes)
        : IRequest<bool>
    {
        public Guid Id { get; init; } = id;
        public string Name { get; init; } = name;
        public decimal Price { get; init; } = price;
        public string? Description { get; init; } = description;
        public List<string> Includes { get; init; } = includes;
    }
}
