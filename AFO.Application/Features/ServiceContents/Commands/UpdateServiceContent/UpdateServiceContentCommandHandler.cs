using AFO.Application.Interfaces;
using AFO.Domain.Entities;
using MediatR;

namespace AFO.Application.Features.ServiceContents.Commands.UpdateServiceContent
{
    public class UpdateServiceContentCommandHandler(IServiceContentRepository serviceContentRepository)
        : IRequestHandler<UpdateServiceContentCommand, bool>
    {
        public async Task<bool> Handle(UpdateServiceContentCommand request, CancellationToken cancellationToken)
        {
            ServiceContent? content = await serviceContentRepository.GetByIdAsync(request.Id);

            if (content is null)
                return false;

            content.Name = request.Name;
            await serviceContentRepository.UpdateAsync(content);

            return true;
        }
    }
}
