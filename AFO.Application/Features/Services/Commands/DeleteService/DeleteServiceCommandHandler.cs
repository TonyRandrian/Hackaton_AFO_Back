using AFO.Application.Interfaces;
using AFO.Domain.Entities;
using MediatR;

namespace AFO.Application.Features.Services.Commands.DeleteService
{
    public class DeleteServiceCommandHandler(IServiceRepository serviceRepository)
        : IRequestHandler<DeleteServiceCommand, bool>
    {
        public async Task<bool> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
        {
            Service? service = await serviceRepository.GetByIdAsync(request.Id);

            if (service is null)
                return false;

            await serviceRepository.DeleteAsync(service);

            return true;
        }
    }
}
