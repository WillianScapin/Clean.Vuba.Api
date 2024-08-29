using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vuba.Application.UseCases.Serie.CreateSerie;
using Vuba.Application.UseCases.Serie.DeleteSerie;
using Vuba.Application.UseCases.Serie.GetAllSerie;
using Vuba.Application.UseCases.Serie.GetSerie;
using Vuba.Application.UseCases.Serie.UpdateSerie;

namespace Vuba.WebAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class SerieController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SerieController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("GetSerie")]
        [Authorize]
        public async Task<ActionResult<GetSerieResponse>> Get(GetSerieRequest request)
        {
            var Serie = await _mediator.Send(request);
            return Ok(Serie);
        }

        [HttpPost("CreateSerie")]
        [Authorize]
        public async Task<ActionResult<CreateSerieResponse>> Create(CreateSerieRequest request)
        {
            var Serie = await _mediator.Send(request);
            return Ok(Serie);
        }

        [HttpPost("GetAllSerie")]
        [Authorize]
        public async Task<ActionResult<GetAllSerieResponse>> GetAll(GetAllSerieRequest request, CancellationToken cancellationToken)
        {
            var Series = await _mediator.Send(request, cancellationToken);
            return Ok(Series);
        }

        [HttpPut("UpdateSerie")]
        [Authorize]
        public async Task<ActionResult<UpdateSerieResponse>> Update(int Id, UpdateSerieRequest request, CancellationToken cancellationToken)
        {
            if (Id != request.Id)
                return BadRequest();

            var Serie = await _mediator.Send(request, cancellationToken);
            return Ok(Serie);
        }

        [HttpDelete("DeleteSerie")]
        [Authorize]
        public async Task<ActionResult<DeleteSerieResponse>> Delete(int id, CancellationToken cancellationToken)
        {
            if (id is 0)
                return BadRequest();

            var deleteSerieRequest = new DeleteSerieRequest(id);
            var response = await _mediator.Send(deleteSerieRequest, cancellationToken);

            return Ok(response);
        }
    }
}
