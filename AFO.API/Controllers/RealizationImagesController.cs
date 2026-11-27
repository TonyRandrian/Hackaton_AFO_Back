
using AFO.Application.Features.RealizationImages.Commands.CreateRealizationImage;
using AFO.Application.Features.RealizationImages.Commands.UpdateRealizationImage;
using AFO.Application.Features.RealizationImages.Commands.DeleteRealizationImage;
using AFO.Application.Features.RealizationImages.Queries.GetRealizationImageById;
using AFO.Application.Features.RealizationImages.Queries.GetRealizationImagesByRealizationId;
using AFO.Application.Features.RealizationImages.Requests;
using AFO.Application.Features.RealizationImages.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AFO.API.Controllers
{
    [ApiController]
    [Route("api")]
    public class RealizationImagesController(ISender sender) : ControllerBase
    {
        [HttpGet("realizations/{realizationId:guid}/images")]
        public async Task<IActionResult> GetByRealizationId(Guid realizationId)
        {
            var images = await sender.Send(new GetRealizationImagesByRealizationIdQuery(realizationId));

            return Ok(images);
        }

        [HttpGet("realization-images/{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            RealizationImageResponse? image = await sender.Send( new GetRealizationImageByIdQuery(id));

            if (image is null)
                return NotFound();

            return Ok(image);
        }

        [HttpPost("realizations/{realizationId:guid}/images")]
        public async Task<IActionResult> Create( Guid realizationId,CreateRealizationImageRequest request)
        {
            Guid? id = await sender.Send(
                new CreateRealizationImageCommand(
                    realizationId,
                    request.Url,
                    request.RealizationImageTypeId));

            if (id is null)
                return NotFound();

            return Created($"/api/realization-images/{id}", id);
        }

        [HttpPut("realization-images/{id:guid}")]
        public async Task<IActionResult> Update(
            Guid id,
            UpdateRealizationImageRequest request)
        {
            bool found = await sender.Send(
                new UpdateRealizationImageCommand(
                    id,
                    request.Url,
                    request.RealizationImageTypeId));

            if (!found)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("realization-images/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            bool found = await sender.Send(  new DeleteRealizationImageCommand(id));

            if (!found)
                return NotFound();

            return NoContent();
        }
    }
}
