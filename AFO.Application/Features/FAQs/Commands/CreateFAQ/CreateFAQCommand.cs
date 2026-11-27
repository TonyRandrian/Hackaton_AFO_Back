using MediatR;

namespace AFO.Application.Features.FAQs.Commands.CreateFAQ
{
    public class CreateFAQCommand(Guid serviceId, string question, string answer)
        : IRequest<Guid?>
    {
        public Guid ServiceId { get; init; } = serviceId;
        public string Question { get; init; } = question;
        public string Answer { get; init; } = answer;
    }
}