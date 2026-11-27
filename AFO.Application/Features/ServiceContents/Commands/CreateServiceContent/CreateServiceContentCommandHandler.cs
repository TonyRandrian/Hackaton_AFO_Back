using AFO.Application.Interfaces;
using AFO.Domain.Entities;
using MediatR;

namespace AFO.Application.Features.ServiceContents.Commands.CreateServiceContent
{
    public class CreateServiceContentCommandHandler(
        IServiceContentRepository serviceContentRepository,
        IServiceRepository serviceRepository)
        : IRequestHandler<CreateServiceContentCommand, Guid?>
    {
        public async Task<Guid?> Handle(CreateServiceContentCommand request, CancellationToken cancellationToken)
        {
            if (!await serviceRepository.ExistsAsync(request.ServiceId))
                return null;

            ServiceContent content = new(
                request.Name, 
                request.ServiceId,
                request.Price,
                request.Description,
                request.Includes);

            await serviceContentRepository.AddAsync(content);
            return content.Id;
        }
    }
}
