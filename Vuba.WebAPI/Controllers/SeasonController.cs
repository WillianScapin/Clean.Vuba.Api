using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vuba.Application.UseCases.Season.CreateSeason;
using Vuba.Application.UseCases.Season.DeleteSeason;
using Vuba.Application.UseCases.Season.GetAllSeason;
using Vuba.Application.UseCases.Season.GetSeason;
using Vuba.Application.UseCases.Season.UpdateSeason;

namespace Vuba.WebAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class SeasonController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SeasonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("GetSeason")]
        [Authorize]
        public async Task<ActionResult<GetSeasonResponse>> Get(GetSeasonRequest request)
        {
            var Season = await _mediator.Send(request);
            return Ok(Season);
        }

        [HttpPost("CreateSeason")]
        [Authorize]
        public async Task<ActionResult<CreateSeasonResponse>> Create(CreateSeasonRequest request)
        {
            var Season = await _mediator.Send(request);
            return Ok(Season);
        }

        [HttpPost("GetAllSeason")]
        [Authorize]
        public async Task<ActionResult<GetAllSeasonResponse>> GetAll(GetAllSeasonRequest request, CancellationToken cancellationToken)
        {
            var Seasons = await _mediator.Send(request, cancellationToken);
            return Ok(Seasons);
        }

        [HttpPut("UpdateSeason")]
        [Authorize]
        public async Task<ActionResult<UpdateSeasonResponse>> Update(int Id, UpdateSeasonRequest request, CancellationToken cancellationToken)
        {
            if (Id != request.Id)
                return BadRequest();

            var Season = await _mediator.Send(request, cancellationToken);
            return Ok(Season);
        }

        [HttpDelete("DeleteSeason")]
        [Authorize]
        public async Task<ActionResult<DeleteSeasonResponse>> Delete(int id, CancellationToken cancellationToken)
        {
            if (id is 0)
                return BadRequest();

            var deleteSeasonRequest = new DeleteSeasonRequest(id);
            var response = await _mediator.Send(deleteSeasonRequest, cancellationToken);

            return Ok(response);
        }
    }
}
