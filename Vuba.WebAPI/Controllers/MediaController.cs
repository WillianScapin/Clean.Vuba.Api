using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vuba.Application.UseCases.Media.GetAllMedia;
using Vuba.Application.UseCases.Movie.GetMovie;

namespace Vuba.WebAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MediaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("GetMedias")]
        //[Authorize]
        public async Task<ActionResult<GetMediaResponse>> Get(GetMediaRequest request)
        {
            var Medias = await _mediator.Send(request);
            return Ok(Medias);
        }

    }
}
