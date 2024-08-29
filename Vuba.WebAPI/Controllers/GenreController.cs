using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vuba.Application.UseCases.Genre.CreateGenre;
using Vuba.Application.UseCases.Genre.DeleteGenre;
using Vuba.Application.UseCases.Genre.GetAllGenre;
using Vuba.Application.UseCases.Genre.GetGenre;
using Vuba.Application.UseCases.Genre.UpdateGenre;

namespace Vuba.WebAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IMediator _mediator;
        public GenreController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("GetGenre")]
        [Authorize]
        [ResponseCache(Duration = (5 * 60))]
        public async Task<ActionResult<GetGenreResponse>> Get(GetGenreRequest request)
        {
            var Genre = await _mediator.Send(request);
            return Ok(Genre);
        }

        [HttpPost("CreateGenre")]
        [Authorize]
        public async Task<ActionResult<CreateGenreResponse>> Create(CreateGenreRequest request)
        {
            var Genre = await _mediator.Send(request);
            return Ok(Genre);
        }

        [HttpPost("GetAllGenre")]
        [Authorize]
        [ResponseCache(Duration = (5 * 60))]
        public async Task<ActionResult<GetAllGenreResponse>> GetAll(GetAllGenreRequest request, CancellationToken cancellationToken)
        {
            var Genres = await _mediator.Send(request, cancellationToken);
            return Ok(Genres);
        }

        [HttpPut("UpdateGenre")]
        [Authorize]
        public async Task<ActionResult<UpdateGenreResponse>> Update(int Id, UpdateGenreRequest request, CancellationToken cancellationToken)
        {
            if (Id != request.Id)
                return BadRequest();

            var Genre = await _mediator.Send(request, cancellationToken);
            return Ok(Genre);
        }

        [HttpDelete("DeleteGenre")]
        [Authorize]
        public async Task<ActionResult<DeleteGenreResponse>> Delete(int id, CancellationToken cancellationToken)
        {
            if (id is 0)
                return BadRequest();

            var deleteGenreRequest = new DeleteGenreRequest(id);
            var response = await _mediator.Send(deleteGenreRequest, cancellationToken);

            return Ok(response);
        }

    }
}
