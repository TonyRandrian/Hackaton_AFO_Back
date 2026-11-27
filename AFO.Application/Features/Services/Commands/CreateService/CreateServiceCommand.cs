using MediatR;

namespace AFO.Application.Features.Services.Commands.CreateService
{
    public class CreateServiceCommand : IRequest<Guid>
    {
        public required string Name { get; init; }
        public required string Title { get; init; }
        public string? ShortDescription { get; init; }
        public string? Image { get; init; }
        public string? Subtitle { get; init; }
        public string? ServiceDescription { get; init; }
        public string? ExpertiseDescription { get; init; }
        public string? RealizationDescription { get; init; }
    }
}
