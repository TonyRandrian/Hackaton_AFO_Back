using AFO.Application.Features.Realizations.Responses;
using AFO.Application.Features.Services.Responses;
using AFO.Application.Interfaces;
using MediatR;

namespace AFO.Application.Features.Services.Queries.GetServiceById
{
    public class GetServiceByIdQueryHandler(IServiceRepository serviceRepository)
        : IRequestHandler<GetServiceByIdQuery, ServiceResponse?>
    {
        public async Task<ServiceResponse?> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var service = await serviceRepository.GetByIdAsync(request.Id);

            if (service is null)
                return null;

            return new ServiceResponse
            {
                Id = service.Id,
                Name = service.Name,
                Title = service.Title,
                ShortDescription = service.ShortDescription,
                Image = service.Image,
                Subtitle = service.Subtitle,
                ServiceDescription = service.ServiceDescription,
                ExpertiseDescription = service.ExpertiseDescription,
                RealizationDescription = service.RealizationDescription,
                Realizations = [.. service.Realizations
                    .Select(r => new RealizationListResponse
                    {
                        Id = r.Id,
                        Name = r.Name,
                        ShortDescription = r.ShortDescription,
                        Title = r.Title,
                        IsPublic = r.IsPublic,
                        ProjectUrl = r.ProjectUrl
                    })
                ]
            };
        }
    }
}
