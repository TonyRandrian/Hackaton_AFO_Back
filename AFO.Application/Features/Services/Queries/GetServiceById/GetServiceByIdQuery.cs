using AFO.Application.Features.Services.Responses;
using MediatR;

namespace AFO.Application.Features.Services.Queries.GetServiceById
{
    public class GetServiceByIdQuery(Guid id) : IRequest<ServiceResponse?>
    {
        public Guid Id { get; init; } = id;
    }
}
