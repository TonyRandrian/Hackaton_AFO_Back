using MediatR;

namespace AFO.Application.Features.FAQs.Commands.UpdateFAQ
{
    public class UpdateFAQCommand(Guid id, string question, string answer)
        : IRequest<bool>
    {
        public Guid Id { get; init; } = id;
        public string Question { get; init; } = question;
        public string Answer { get; init; } = answer;
    }
}