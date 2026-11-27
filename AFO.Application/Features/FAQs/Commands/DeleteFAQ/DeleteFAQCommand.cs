using MediatR;

namespace AFO.Application.Features.FAQs.Commands.DeleteFAQ
{
    public class DeleteFAQCommand(Guid id) : IRequest<bool>
    {
        public Guid Id { get; init; } = id;
    }
}