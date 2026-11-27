
using MediatR;
namespace AFO.Application.Features.Realizations.Commands.DeleteRealization;

public record DeleteRealizationCommand(Guid Id) : IRequest<bool>;
