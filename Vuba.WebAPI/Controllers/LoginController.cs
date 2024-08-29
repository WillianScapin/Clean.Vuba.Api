using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vuba.Application.UseCases.Login.CreateLogin;
using Vuba.Domain.Interfaces;

namespace Vuba.WebAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IJwtAuthenticationService _jwtAuthenticationService;

        public LoginController(IMediator mediator, IJwtAuthenticationService jwtAuthenticationService)
        {
            _mediator = mediator;
            _jwtAuthenticationService = jwtAuthenticationService;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<CreateLoginResponse>> CreateLogin(CreateLoginRequest request)
        {
            var login = await _mediator.Send(request);
            if (login == null) return NotFound();

            string jwt = _jwtAuthenticationService.GenerateToken(login.AccountId);
            _jwtAuthenticationService.SetTokenCookie(HttpContext, jwt);

            login.Token = jwt;
            return Ok(login);
        }

    }
}
