using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vuba.Application.UseCases.Episode.CreateEpisode;
using Vuba.Application.UseCases.Episode.DeleteEpisode;
using Vuba.Application.UseCases.Episode.GetEpisode;
using Vuba.Application.UseCases.Episode.GetAllEpisode;
using Vuba.Application.UseCases.Episode.UpdateEpisode;

namespace Vuba.WebAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class EpisodeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EpisodeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("GetEpisode")]
        [Authorize]
        public async Task<ActionResult<GetEpisodeResponse>> Get(GetEpisodeRequest request)
        {
            var Episode = await _mediator.Send(request);
            return Ok(Episode);
        }

        [HttpPost("CreateEpisode")]
        [Authorize]
        public async Task<ActionResult<CreateEpisodeResponse>> Create(CreateEpisodeRequest request)
        {
            var Episode = await _mediator.Send(request);
            return Ok(Episode);
        }

        [HttpPost("GetAllEpisode")]
        [Authorize]
        public async Task<ActionResult<GetAllEpisodeResponse>> GetAll(GetAllEpisodeRequest request, CancellationToken cancellationToken)
        {
            var Episodes = await _mediator.Send(request, cancellationToken);
            return Ok(Episodes);
        }

        [HttpPut("UpdateEpisode")]
        [Authorize]
        public async Task<ActionResult<UpdateEpisodeResponse>> Update(int Id, UpdateEpisodeRequest request, CancellationToken cancellationToken)
        {
            if (Id != request.Id)
                return BadRequest();

            var Episode = await _mediator.Send(request, cancellationToken);
            return Ok(Episode);
        }

        [HttpDelete("DeleteEpisode")]
        [Authorize]
        public async Task<ActionResult<DeleteEpisodeResponse>> Delete(int id, CancellationToken cancellationToken)
        {
            if (id is 0)
                return BadRequest();

            var deleteEpisodeRequest = new DeleteEpisodeRequest(id);
            var response = await _mediator.Send(deleteEpisodeRequest, cancellationToken);

            return Ok(response);
        }



    }
}
