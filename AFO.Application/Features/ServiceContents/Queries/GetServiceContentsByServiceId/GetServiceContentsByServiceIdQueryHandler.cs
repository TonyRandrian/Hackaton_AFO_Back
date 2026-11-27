using AFO.Application.Features.ServiceContents.Responses;
using AFO.Application.Interfaces;
using AFO.Domain.Entities;
using MediatR;

namespace AFO.Application.Features.ServiceContents.Queries.GetServiceContentsByServiceId
{
    public class GetServiceContentsByServiceIdQueryHandler(IServiceContentRepository serviceContentRepository)
        : IRequestHandler<GetServiceContentsByServiceIdQuery, List<ServiceContentListResponse>>
    {
        public async Task<List<ServiceContentListResponse>> Handle(GetServiceContentsByServiceIdQuery request, CancellationToken cancellationToken)
        {
            List<ServiceContent> contents = await serviceContentRepository.GetByServiceIdAsync(request.ServiceId);

            return [.. contents
                .Select(c => new ServiceContentListResponse
                {
                    Id = c.Id,
                    Name = c.Name,
                    Price = c.Price,
                    Description = c.Description,
                    Includes = c.Includes
                })];
        }
    }
}
