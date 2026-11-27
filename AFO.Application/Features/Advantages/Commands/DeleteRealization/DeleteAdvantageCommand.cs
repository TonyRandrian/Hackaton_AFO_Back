
using MediatR;

namespace AFO.Application.Features.Advantages.Commands.DeleteAdvantage;

public record DeleteAdvantageCommand(Guid Id) : IRequest<bool>;
