using AFO.Application.Interfaces;
using AFO.Domain.Entities;
using MediatR;

namespace AFO.Application.Features.FAQs.Commands.DeleteFAQ
{
    public class DeleteFAQCommandHandler(IFAQRepository faqRepository)
        : IRequestHandler<DeleteFAQCommand, bool>
    {
        public async Task<bool> Handle(DeleteFAQCommand request, CancellationToken cancellationToken)
        {
            FAQ? faq = await faqRepository.GetByIdAsync(request.Id);

            if (faq is null)
                return false;

            await faqRepository.DeleteAsync(faq);

            return true;
        }
    }
}