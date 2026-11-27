
using MediatR;

namespace AFO.Application.Features.Advantages.Commands.UpdateAdvantage;

public record UpdateAdvantageCommand( Guid Id, string Name,string? Description) : IRequest<bool>;
