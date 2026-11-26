using AFO.Application.Features.ServiceContents.Responses;
using MediatR;

namespace AFO.Application.Features.ServiceContents.Queries.GetServiceContentsByServiceId
{
    public class GetServiceContentsByServiceIdQuery(Guid serviceId)
        : IRequest<List<ServiceContentListResponse>>
    {
        public Guid ServiceId { get; init; } = serviceId;
    }
}
