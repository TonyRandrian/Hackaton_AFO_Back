using AFO.Application.Features.ServiceContents.Responses;
using AFO.Application.Interfaces;
using AFO.Domain.Entities;
using MediatR;

namespace AFO.Application.Features.ServiceContents.Queries.GetServiceContentById
{
    public class GetServiceContentByIdQueryHandler(IServiceContentRepository serviceContentRepository)
        : IRequestHandler<GetServiceContentByIdQuery, ServiceContentResponse?>
    {
        public async Task<ServiceContentResponse?> Handle(GetServiceContentByIdQuery request, CancellationToken cancellationToken)
        {
            ServiceContent? content = await serviceContentRepository.GetByIdAsync(request.Id);

            if (content is null)
                return null;

            return new ServiceContentResponse
            {
                Id = content.Id,
                Name = content.Name,
                ServiceId = content.ServiceId
            };
        }
    }
}
