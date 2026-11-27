using AFO.Application.Features.ServiceContents.Responses;
using MediatR;

namespace AFO.Application.Features.ServiceContents.Queries.GetServiceContentById
{
    public class GetServiceContentByIdQuery(Guid id) 
        : IRequest<ServiceContentResponse?>
    {
        public Guid Id { get; init; } = id;
    }
}
