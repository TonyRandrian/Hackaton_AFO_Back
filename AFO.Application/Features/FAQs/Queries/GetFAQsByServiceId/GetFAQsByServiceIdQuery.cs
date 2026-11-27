using AFO.Application.Features.FAQs.Responses;
using MediatR;

namespace AFO.Application.Features.FAQs.Queries.GetFAQsByServiceId
{
    public class GetFAQsByServiceIdQuery(Guid serviceId)
        : IRequest<List<FAQListResponse>>
    {
        public Guid ServiceId { get; init; } = serviceId;
    }
}