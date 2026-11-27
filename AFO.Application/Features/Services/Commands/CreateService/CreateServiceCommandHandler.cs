using AFO.Application.Interfaces;
using AFO.Domain.Entities;
using MediatR;

namespace AFO.Application.Features.Services.Commands.CreateService
{
    public class CreateServiceCommandHandler(IServiceRepository serviceRepository)
        : IRequestHandler<CreateServiceCommand, Guid>
    {
        public async Task<Guid> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            Service service = new(request.Name, request.Title)
            {
                ShortDescription = request.ShortDescription,
                Image = request.Image,
                Subtitle = request.Subtitle,
                ServiceDescription = request.ServiceDescription,
                ExpertiseDescription = request.ExpertiseDescription,
                RealizationDescription = request.RealizationDescription
            };

            await serviceRepository.AddAsync(service);

            return service.Id;
        }
    }
}
