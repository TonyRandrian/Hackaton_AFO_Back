using AFO.Application.Features.ServiceContents.Commands.CreateServiceContent;
using AFO.Application.Features.ServiceContents.Commands.DeleteServiceContent;
using AFO.Application.Features.ServiceContents.Commands.UpdateServiceContent;
using AFO.Application.Features.ServiceContents.Queries.GetServiceContentById;
using AFO.Application.Features.ServiceContents.Queries.GetServiceContentsByServiceId;
using AFO.Application.Features.ServiceContents.Requests;
using AFO.Application.Features.ServiceContents.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AFO.API.Controllers
{
    [ApiController]
    [Route("api")]
    public class ServiceContentsController(ISender sender) : ControllerBase
    {

        [HttpGet("services/{serviceId:guid}/contents")]
        public async Task<IActionResult> GetByServiceId(Guid serviceId)
        {
            List<ServiceContentListResponse> contents = await sender.Send(new GetServiceContentsByServiceIdQuery(serviceId));
            return Ok(contents);
        }

        [HttpGet("service-contents/{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            ServiceContentResponse? content = await sender.Send(new GetServiceContentByIdQuery(id));

            if (content is null)
                return NotFound();

            return Ok(content);
        }

        [HttpPost("services/{serviceId:guid}/contents")]
        public async Task<IActionResult> Create(Guid serviceId, CreateServiceContentRequest request)
        {
            Guid? id = await sender.Send(new CreateServiceContentCommand(serviceId, request.Name));

            if (id is null)
                return NotFound();

            return Created($"/api/service-contents/{id}", id);
        }

        [HttpPut("service-contents/{id:guid}")]
        public async Task<IActionResult> Update(Guid id, UpdateServiceContentRequest request)
        {
            bool found = await sender.Send(new UpdateServiceContentCommand(id, request.Name));

            if (!found)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("service-contents/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            bool found = await sender.Send(new DeleteServiceContentCommand(id));

            if (!found)
                return NotFound();

            return NoContent();
        }
    }
}
