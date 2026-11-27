
using MediatR;

namespace AFO.Application.Features.Advantages.Commands.CreateAdvantage;

public record CreateAdvantageCommand(string Name,string? Description) : IRequest<Guid>;
