using AFO.Application.Features.ServiceContents.Responses;
using AFO.Application.Features.Services.Responses;
using AFO.Application.Interfaces;
using MediatR;

namespace AFO.Application.Features.Services.Queries.GetServices
{
    public class GetServicesQueryHandler(IServiceRepository serviceRepository)
        : IRequestHandler<GetServicesQuery, List<ServiceListResponse>>
    {
        public async Task<List<ServiceListResponse>> Handle(GetServicesQuery request, CancellationToken cancellationToken)
        {
            var services = await serviceRepository.GetAllAsync();

            return [.. services
                .Select(s => new ServiceListResponse
                {
                    Id = s.Id,
                    Name = s.Name,
                    ShortDescription = s.ShortDescription,
                    Image = s.Image,
                    Contents = [.. s.Contents
                        .Select(c => new ServiceContentListResponse {
                            Id = c.Id,
                            Name = c.Name
                        })]
                })];
        }
    }
}
