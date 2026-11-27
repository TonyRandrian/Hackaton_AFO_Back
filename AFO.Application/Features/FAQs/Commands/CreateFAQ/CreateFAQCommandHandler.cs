using AFO.Application.Interfaces;
using AFO.Domain.Entities;
using MediatR;

namespace AFO.Application.Features.FAQs.Commands.CreateFAQ
{
    public class CreateFAQCommandHandler(
        IFAQRepository faqRepository,
        IServiceRepository serviceRepository)
        : IRequestHandler<CreateFAQCommand, Guid?>
    {
        public async Task<Guid?> Handle(CreateFAQCommand request, CancellationToken cancellationToken)
        {
            if (!await serviceRepository.ExistsAsync(request.ServiceId))
                return null;

            FAQ faq = new()
            {
                Id = Guid.NewGuid(),
                ServiceId = request.ServiceId,
                Question = request.Question,
                Answer = request.Answer
            };

            await faqRepository.AddAsync(faq);

            return faq.Id;
        }
    }
}