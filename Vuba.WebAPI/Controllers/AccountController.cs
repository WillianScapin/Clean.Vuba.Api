using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vuba.Application.UseCases.Account.CreateAccount;
using Vuba.Application.UseCases.Account.DeleteAccount;
using Vuba.Application.UseCases.Account.GetAccount;
using Vuba.Application.UseCases.Account.GetAllAccount;
using Vuba.Application.UseCases.Account.UpdateAccount;
using Vuba.Application.UseCases.Account.UpdateUser;
using Vuba.Domain.Entities;
using Vuba.Domain.Interfaces;

namespace Vuba.WebAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IJwtAuthenticationService _jwtAuthenticationService;
        public AccountController(IMediator mediator, IJwtAuthenticationService jwtAuthenticationService)
        {
            _mediator = mediator;
            _jwtAuthenticationService = jwtAuthenticationService;
        }

        [HttpPost("GetAccount")]
        [Authorize]
        public async Task<ActionResult<GetAccountResponse>> Get(GetAccountRequest request)
        {
            var account = await _mediator.Send(request);
            return Ok(account);
        }

        [HttpPost("CreateAccount")]
        public async Task<ActionResult<CreateAccountResponse>> Create(CreateAccountRequest request)
        {
            var account = await _mediator.Send(request);

            var token = _jwtAuthenticationService.GenerateToken(account.Id);
            _jwtAuthenticationService.SetTokenCookie(HttpContext, token);

            account.Token = token;

            return Ok(account);
        }

        [HttpPost("GetAllAccount")]
        [Authorize]
        public async Task<ActionResult<GetAllAccountResponse>> GetAll(GetAllAccountRequest request, CancellationToken cancellationToken)
        {
            var accounts = await _mediator.Send(request, cancellationToken);
            return Ok(accounts);
        }

        [HttpPut("UpdateAccount")]
        [Authorize]
        public async Task<ActionResult<UpdateAccountResponse>> Update(int id, UpdateAccountRequest request, CancellationToken cancellationToken)
        {
            if (id != request.id)
                return BadRequest();

            var account = await _mediator.Send(request, cancellationToken);
            return Ok(account);
        }

        [HttpDelete("DeleteAccount")]
        [Authorize]
        public async Task<ActionResult<DeleteAccountResponse>> Delete(int id, CancellationToken cancellationToken)
        {
            if (id is 0)
                return BadRequest();

            var deleteAccountRequest = new DeleteAccountRequest(id);
            var response = await _mediator.Send(deleteAccountRequest, cancellationToken);

            return Ok(response);
        }
    }
}
