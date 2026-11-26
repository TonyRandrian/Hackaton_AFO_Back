using AFO.Application.Features.Services.Responses;
using MediatR;

namespace AFO.Application.Features.Services.Queries.GetServices
{
    public class GetServicesQuery : IRequest<List<ServiceListResponse>>;
}
