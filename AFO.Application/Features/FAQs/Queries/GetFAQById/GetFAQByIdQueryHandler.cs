using AFO.Application.Features.FAQs.Responses;
using AFO.Application.Interfaces;
using MediatR;

namespace AFO.Application.Features.FAQs.Queries.GetFAQById
{
    public class GetFAQByIdQueryHandler(IFAQRepository faqRepository)
        : IRequestHandler<GetFAQByIdQuery, FAQResponse?>
    {
        public async Task<FAQResponse?> Handle(GetFAQByIdQuery request, CancellationToken cancellationToken)
        {
            var faq = await faqRepository.GetByIdAsync(request.Id);

            if (faq is null)
                return null;

            return new FAQResponse
            {
                Id = faq.Id,
                ServiceId = faq.ServiceId,
                Question = faq.Question,
                Answer = faq.Answer
            };
        }
    }
}