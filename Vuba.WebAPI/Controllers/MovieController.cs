using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vuba.Application.UseCases.Movie.CreateMovie;
using Vuba.Application.UseCases.Movie.DeleteMovie;
using Vuba.Application.UseCases.Movie.GetAllMovie;
using Vuba.Application.UseCases.Movie.GetMovie;
using Vuba.Application.UseCases.Movie.UpdateMovie;

namespace Vuba.WebAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MovieController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("GetMovie")]
        [Authorize]
        public async Task<ActionResult<GetMovieResponse>> Get(GetMovieRequest request)
        {
            var Movie = await _mediator.Send(request);
            return Ok(Movie);
        }

        [HttpPost("CreateMovie")]
        [Authorize]
        public async Task<ActionResult<CreateMovieResponse>> Create(CreateMovieRequest request)
        {
            var Movie = await _mediator.Send(request);
            return Ok(Movie);
        }

        [HttpPost("GetAllMovie")]
        [Authorize]
        public async Task<ActionResult<GetAllMovieResponse>> GetAll(GetAllMovieRequest request, CancellationToken cancellationToken)
        {
            var Movies = await _mediator.Send(request, cancellationToken);
            return Ok(Movies);
        }

        [HttpPut("UpdateMovie")]
        [Authorize]
        public async Task<ActionResult<UpdateMovieResponse>> Update(int Id, UpdateMovieRequest request, CancellationToken cancellationToken)
        {
            if (Id != request.Id)
                return BadRequest();

            var Movie = await _mediator.Send(request, cancellationToken);
            return Ok(Movie);
        }

        [HttpDelete("DeleteMovie")]
        [Authorize]
        public async Task<ActionResult<DeleteMovieResponse>> Delete(int id, CancellationToken cancellationToken)
        {
            if (id is 0)
                return BadRequest();

            var deleteMovieRequest = new DeleteMovieRequest(id);
            var response = await _mediator.Send(deleteMovieRequest, cancellationToken);

            return Ok(response);
        }
    }
}
