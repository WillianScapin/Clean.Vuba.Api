using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vuba.Application.UseCases.Level.CreateLevel;
using Vuba.Application.UseCases.Level.DeleteLevel;
using Vuba.Application.UseCases.Level.GetAllLevel;
using Vuba.Application.UseCases.Level.GetLevel;
using Vuba.Application.UseCases.Level.UpdateLevel;

namespace Vuba.WebAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class LevelController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LevelController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("GetLevel")]
        [Authorize]
        [ResponseCache(Duration = (5 * 60))]
        public async Task<ActionResult<GetLevelResponse>> Get(GetLevelRequest request)
        {
            var Level = await _mediator.Send(request);
            return Ok(Level);
        }

        [HttpPost("CreateLevel")]
        [Authorize]
        public async Task<ActionResult<CreateLevelResponse>> Create(CreateLevelRequest request)
        {
            var Level = await _mediator.Send(request);
            return Ok(Level);
        }

        [HttpPost("GetAllLevel")]
        [Authorize]
        [ResponseCache(Duration = (5 * 60))]
        public async Task<ActionResult<GetAllLevelResponse>> GetAll(GetAllLevelRequest request, CancellationToken cancellationToken)
        {
            var Levels = await _mediator.Send(request, cancellationToken);
            return Ok(Levels);
        }

        [HttpPut("UpdateLevel")]
        [Authorize]
        public async Task<ActionResult<UpdateLevelResponse>> Update(int Id, UpdateLevelRequest request, CancellationToken cancellationToken)
        {
            if (Id != request.Id)
                return BadRequest();

            var Level = await _mediator.Send(request, cancellationToken);
            return Ok(Level);
        }

        [HttpDelete("DeleteLevel")]
        [Authorize]
        public async Task<ActionResult<DeleteLevelResponse>> Delete(int id, CancellationToken cancellationToken)
        {
            if (id is 0)
                return BadRequest();

            var deleteLevelRequest = new DeleteLevelRequest(id);
            var response = await _mediator.Send(deleteLevelRequest, cancellationToken);

            return Ok(response);
        }

    }
}
