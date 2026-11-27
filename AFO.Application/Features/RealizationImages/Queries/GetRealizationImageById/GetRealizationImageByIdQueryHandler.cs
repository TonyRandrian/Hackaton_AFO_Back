
using AFO.Application.Features.RealizationImages.Responses;
using AFO.Application.Interfaces;
using MediatR;

namespace AFO.Application.Features.RealizationImages.Queries.GetRealizationImageById
{
    public class GetRealizationImageByIdQueryHandler(IRealizationImageRepository imageRepository)
        : IRequestHandler<GetRealizationImageByIdQuery, RealizationImageResponse?>
    {
        public async Task<RealizationImageResponse?> Handle(  GetRealizationImageByIdQuery request,
            CancellationToken cancellationToken)
        {
            var image = await imageRepository.GetByIdAsync(request.Id);

            if (image is null)
                return null;

            return new RealizationImageResponse
            {
                Id = image.Id,
                Url = image.Url,
                RealizationId = image.RealizationId,
                RealizationImageTypeId = image.RealizationImageTypeId,
                TypeName = image.RealizationImageType.Name
            };
        }
    }
}
