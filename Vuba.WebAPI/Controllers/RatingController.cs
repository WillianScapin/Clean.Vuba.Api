using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vuba.Application.UseCases.Rating.CreateRating;
using Vuba.Application.UseCases.Rating.DeleteRating;
using Vuba.Application.UseCases.Rating.GetAllRating;
using Vuba.Application.UseCases.Rating.GetRating;
using Vuba.Application.UseCases.Rating.UpdateRating;

namespace Vuba.WebAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RatingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("GetRating")]
        [Authorize]
        [ResponseCache(Duration = (5 * 60))]
        public async Task<ActionResult<GetRatingResponse>> Get(GetRatingRequest request)
        {
            var Rating = await _mediator.Send(request);
            return Ok(Rating);
        }

        [HttpPost("CreateRating")]
        [Authorize]
        public async Task<ActionResult<CreateRatingResponse>> Create(CreateRatingRequest request)
        {
            var Rating = await _mediator.Send(request);
            return Ok(Rating);
        }

        [HttpPost("GetAllRating")]
        [Authorize]
        [ResponseCache(Duration = (5 * 60))]
        public async Task<ActionResult<GetAllRatingResponse>> GetAll(GetAllRatingRequest request, CancellationToken cancellationToken)
        {
            var Ratings = await _mediator.Send(request, cancellationToken);
            return Ok(Ratings);
        }

        [HttpPut("UpdateRating")]
        [Authorize]
        public async Task<ActionResult<UpdateRatingResponse>> Update(int Id, UpdateRatingRequest request, CancellationToken cancellationToken)
        {
            if (Id != request.Id)
                return BadRequest();

            var Rating = await _mediator.Send(request, cancellationToken);
            return Ok(Rating);
        }

        [HttpDelete("DeleteRating")]
        [Authorize]
        public async Task<ActionResult<DeleteRatingResponse>> Delete(int id, CancellationToken cancellationToken)
        {
            if (id is 0)
                return BadRequest();

            var deleteRatingRequest = new DeleteRatingRequest(id);
            var response = await _mediator.Send(deleteRatingRequest, cancellationToken);

            return Ok(response);
        }
    }
}
