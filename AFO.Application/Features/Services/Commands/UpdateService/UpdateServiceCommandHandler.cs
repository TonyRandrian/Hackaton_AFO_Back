using AFO.Application.Interfaces;
using AFO.Domain.Entities;
using MediatR;

namespace AFO.Application.Features.Services.Commands.UpdateService
{
    public class UpdateServiceCommandHandler(IServiceRepository serviceRepository)
        : IRequestHandler<UpdateServiceCommand, bool>
    {
        public async Task<bool> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            Service? service = await serviceRepository.GetByIdAsync(request.Id);

            if (service is null)
                return false;

            service.Name = request.Name;
            service.Title = request.Title;
            service.ShortDescription = request.ShortDescription;
            service.Image = request.Image;
            service.Subtitle = request.Subtitle;
            service.ServiceDescription = request.ServiceDescription;
            service.ExpertiseDescription = request.ExpertiseDescription;
            service.RealizationDescription = request.RealizationDescription;

            await serviceRepository.UpdateAsync(service);

            return true;
        }
    }
}
