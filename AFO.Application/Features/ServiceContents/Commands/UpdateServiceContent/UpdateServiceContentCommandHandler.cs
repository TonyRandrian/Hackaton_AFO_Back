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
            content.Price = request.Price;
            content.Description = request.Description;
            content.Includes = request.Includes;

            await serviceContentRepository.UpdateAsync(content);

            return true;
        }
    }
}
