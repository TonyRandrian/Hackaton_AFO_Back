
using AFO.Application.Interfaces;
using MediatR;

namespace AFO.Application.Features.RealizationImages.Commands.UpdateRealizationImage
{
    public class UpdateRealizationImageCommandHandler(
        IRealizationImageRepository imageRepository)
        : IRequestHandler<UpdateRealizationImageCommand, bool>
    {
        public async Task<bool> Handle(
            UpdateRealizationImageCommand request,
            CancellationToken cancellationToken)
        {
            var image = await imageRepository.GetByIdAsync(request.Id);

            if (image is null)
                return false;

            if (!await imageRepository.ImageTypeExistsAsync(
                request.RealizationImageTypeId))
                return false;

            image.Update(
                request.Url,
                request.RealizationImageTypeId);

            await imageRepository.UpdateAsync(image);

            return true;
        }
    }
}
