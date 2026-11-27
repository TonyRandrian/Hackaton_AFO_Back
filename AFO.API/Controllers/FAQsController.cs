using AFO.Application.Features.FAQs.Commands.CreateFAQ;
using AFO.Application.Features.FAQs.Commands.DeleteFAQ;
using AFO.Application.Features.FAQs.Commands.UpdateFAQ;
using AFO.Application.Features.FAQs.Queries.GetFAQById;
using AFO.Application.Features.FAQs.Queries.GetFAQsByServiceId;
using AFO.Application.Features.FAQs.Requests;
using AFO.Application.Features.FAQs.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AFO.API.Controllers
{
    [ApiController]
    [Route("api")]
    public class FAQsController(ISender sender) : ControllerBase
    {
        [HttpGet("services/{serviceId:guid}/faqs")]
        public async Task<IActionResult> GetByServiceId(Guid serviceId)
        {
            List<FAQListResponse> faqs = await sender.Send(new GetFAQsByServiceIdQuery(serviceId));
            return Ok(faqs);
        }

        [HttpGet("faqs/{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            FAQResponse? faq = await sender.Send(new GetFAQByIdQuery(id));

            if (faq is null)
                return NotFound();

            return Ok(faq);
        }

        [HttpPost("services/{serviceId:guid}/faqs")]
        public async Task<IActionResult> Create(Guid serviceId, CreateFAQRequest request)
        {
            Guid? id = await sender.Send(new CreateFAQCommand(
                serviceId, request.Question, request.Answer));

            if (id is null)
                return NotFound();

            return Created($"/api/faqs/{id}", id);
        }

        [HttpPut("faqs/{id:guid}")]
        public async Task<IActionResult> Update(Guid id, UpdateFAQRequest request)
        {
            bool found = await sender.Send(new UpdateFAQCommand(
                id, request.Question, request.Answer));

            if (!found)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("faqs/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            bool found = await sender.Send(new DeleteFAQCommand(id));

            if (!found)
                return NotFound();

            return NoContent();
        }
    }
}
