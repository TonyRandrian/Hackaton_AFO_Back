
using AFO.Application.Interfaces;
using MediatR;

namespace AFO.Application.Features.RealizationImages.Commands.DeleteRealizationImage
{
    public class DeleteRealizationImageCommandHandler(
        IRealizationImageRepository imageRepository)
        : IRequestHandler<DeleteRealizationImageCommand, bool>
    {
        public async Task<bool> Handle(
            DeleteRealizationImageCommand request,
            CancellationToken cancellationToken)
        {
            var image = await imageRepository.GetByIdAsync(request.Id);

            if (image is null)
                return false;

            await imageRepository.DeleteAsync(image);

            return true;
        }
    }
}
