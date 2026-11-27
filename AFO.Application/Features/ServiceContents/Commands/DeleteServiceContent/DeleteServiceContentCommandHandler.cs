using AFO.Application.Interfaces;
using AFO.Domain.Entities;
using MediatR;

namespace AFO.Application.Features.ServiceContents.Commands.DeleteServiceContent
{
    public class DeleteServiceContentCommandHandler(IServiceContentRepository serviceContentRepository)
        : IRequestHandler<DeleteServiceContentCommand, bool>
    {
        public async Task<bool> Handle(DeleteServiceContentCommand request, CancellationToken cancellationToken)
        {
            ServiceContent? content = await serviceContentRepository.GetByIdAsync(request.Id);

            if (content is null)
                return false;

            await serviceContentRepository.DeleteAsync(content);

            return true;
        }
    }
}
