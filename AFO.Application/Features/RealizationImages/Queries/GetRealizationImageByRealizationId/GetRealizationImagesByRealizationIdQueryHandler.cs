
using AFO.Application.Features.RealizationImages.Responses;
using AFO.Application.Interfaces;
using MediatR;

namespace AFO.Application.Features.RealizationImages.Queries.GetRealizationImagesByRealizationId
{
    public class GetRealizationImagesByRealizationIdQueryHandler(
        IRealizationImageRepository imageRepository)
        : IRequestHandler<GetRealizationImagesByRealizationIdQuery, List<RealizationImageListResponse>>
    {
        public async Task<List<RealizationImageListResponse>> Handle(
            GetRealizationImagesByRealizationIdQuery request,
            CancellationToken cancellationToken)
        {
            var images = await imageRepository.GetByRealizationIdAsync(  request.RealizationId);

            return [.. images.Select(i => new RealizationImageListResponse
            {
                Id = i.Id,
                Url = i.Url,
                RealizationImageTypeId = i.RealizationImageTypeId,
                TypeName = i.RealizationImageType.Name
            })];
        }
    }
}
