using AFO.Application.Features.FAQs.Responses;
using MediatR;

namespace AFO.Application.Features.FAQs.Queries.GetFAQById
{
    public class GetFAQByIdQuery(Guid id) : IRequest<FAQResponse?>
    {
        public Guid Id { get; init; } = id;
    }
}