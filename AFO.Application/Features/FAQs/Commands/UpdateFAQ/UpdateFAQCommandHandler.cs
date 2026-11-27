using AFO.Application.Interfaces;
using AFO.Domain.Entities;
using MediatR;

namespace AFO.Application.Features.FAQs.Commands.UpdateFAQ
{
    public class UpdateFAQCommandHandler(IFAQRepository faqRepository)
        : IRequestHandler<UpdateFAQCommand, bool>
    {
        public async Task<bool> Handle(UpdateFAQCommand request, CancellationToken cancellationToken)
        {
            FAQ? faq = await faqRepository.GetByIdAsync(request.Id);

            if (faq is null)
                return false;

            faq.Question = request.Question;
            faq.Answer = request.Answer;

            await faqRepository.UpdateAsync(faq);

            return true;
        }
    }
}