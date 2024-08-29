using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuba.Domain.Interfaces;

namespace Vuba.Application.UseCases.Login.CreateLogin
{
    public class CreateLoginHandler : IRequestHandler<CreateLoginRequest, CreateLoginResponse>
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IJwtAuthenticationService _jwtAuthenticationService;
        private readonly IMapper _mapper;

        public CreateLoginHandler(ILoginRepository loginRepository, IMapper mapper, IJwtAuthenticationService jwtAuthenticationService)
        {
            _loginRepository = loginRepository;
            _mapper = mapper;
            _jwtAuthenticationService = jwtAuthenticationService;
        }

        public async Task<CreateLoginResponse> Handle(CreateLoginRequest request, CancellationToken cancellationToken)
        {
            var account = await _loginRepository.Get(request.Email, request.Password, cancellationToken);
            if (account == null) return default;

            var responseLogin = new CreateLoginResponse()
            {
                AccountId = account.Id,
            };

            return responseLogin;
        }
    }
}
