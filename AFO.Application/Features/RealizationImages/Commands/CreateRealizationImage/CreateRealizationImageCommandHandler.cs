
using AFO.Application.Interfaces;
using AFO.Domain.Entities;
using MediatR;

namespace AFO.Application.Features.RealizationImages.Commands.CreateRealizationImage
{
    public class CreateRealizationImageCommandHandler(IRealizationImageRepository imageRepository)
        : IRequestHandler<CreateRealizationImageCommand, Guid?>
    {
        public async Task<Guid?> Handle(CreateRealizationImageCommand request, CancellationToken cancellationToken)
        {
            if (!await imageRepository.RealizationExistsAsync(request.RealizationId))
                return null;

            if (!await imageRepository.ImageTypeExistsAsync(request.RealizationImageTypeId))
                return null;

            RealizationImage image = new(
                request.Url,
                request.RealizationId,
                request.RealizationImageTypeId);

            await imageRepository.AddAsync(image);
            return image.Id;
        }
    }
}
