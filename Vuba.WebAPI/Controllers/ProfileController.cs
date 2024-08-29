using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vuba.Application.UseCases.Profile.CreateProfile;
using Vuba.Application.UseCases.Profile.DeleteProfile;
using Vuba.Application.UseCases.Profile.GetAllProfile;
using Vuba.Application.UseCases.Profile.GetProfile;
using Vuba.Application.UseCases.Profile.UpdateProfile;

namespace Vuba.WebAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProfileController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("GetProfile")]
        [Authorize]
        public async Task<ActionResult<GetProfileResponse>> Get(GetProfileRequest request)
        {
            var Profile = await _mediator.Send(request);
            return Ok(Profile);
        }

        [HttpPost("CreateProfile")]
        [Authorize]
        public async Task<ActionResult<CreateProfileResponse>> Create(CreateProfileRequest request)
        {
            var Profile = await _mediator.Send(request);
            return Ok(Profile);
        }

        [HttpPost("GetAllProfile")]
        [Authorize]
        public async Task<ActionResult<GetAllProfileResponse>> GetAll(GetAllProfileRequest request, CancellationToken cancellationToken)
        {
            var Profiles = await _mediator.Send(request, cancellationToken);
            return Ok(Profiles);
        }

        [HttpPut("UpdateProfile")]
        [Authorize]
        public async Task<ActionResult<UpdateProfileResponse>> Update(int Id, UpdateProfileRequest request, CancellationToken cancellationToken)
        {
            if (Id != request.Id)
                return BadRequest();

            var Profile = await _mediator.Send(request, cancellationToken);
            return Ok(Profile);
        }

        [HttpDelete("DeleteProfile")]
        [Authorize]
        public async Task<ActionResult<DeleteProfileResponse>> Delete(int id, CancellationToken cancellationToken)
        {
            if (id is 0)
                return BadRequest();

            var deleteProfileRequest = new DeleteProfileRequest(id);
            var response = await _mediator.Send(deleteProfileRequest, cancellationToken);

            return Ok(response);
        }
    }
}
