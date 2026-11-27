using AFO.Application.Features.FAQs.Responses;
using AFO.Application.Interfaces;
using MediatR;

namespace AFO.Application.Features.FAQs.Queries.GetFAQsByServiceId
{
    public class GetFAQsByServiceIdQueryHandler(IFAQRepository faqRepository)
        : IRequestHandler<GetFAQsByServiceIdQuery, List<FAQListResponse>>
    {
        public async Task<List<FAQListResponse>> Handle(GetFAQsByServiceIdQuery request, CancellationToken cancellationToken)
        {
            var faqs = await faqRepository.GetByServiceIdAsync(request.ServiceId);

            return [.. faqs
                .Select(f => new FAQListResponse
                {
                    Id = f.Id,
                    Question = f.Question,
                    Answer = f.Answer
                })];
        }
    }
}