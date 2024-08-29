using AutoMapper;
using MediatR;
using Vuba.Domain.Interfaces;
using Vuba.Domain.Entities;


namespace Vuba.Application.UseCases.Account.CreateAccount
{
    public sealed class CreateAccountHandler : IRequestHandler<CreateAccountRequest, CreateAccountResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        private readonly IJwtAuthenticationService _jwtAuthenticationService;

        public CreateAccountHandler(IUnitOfWork unitOfWork, IAccountRepository accountRepository, IMapper mapper, IJwtAuthenticationService jwtAuthenticationService)
        {
            _unitOfWork = unitOfWork;
            _accountRepository = accountRepository;
            _mapper = mapper;
            _jwtAuthenticationService = jwtAuthenticationService;
        }

        public async Task<CreateAccountResponse> Handle(CreateAccountRequest request, CancellationToken cancellationToken)
        {
            var account = _mapper.Map<Domain.Entities.Account>(request);

            _accountRepository.Create(account);
            await _unitOfWork.Commit(cancellationToken);

            var accountResponse = _mapper.Map<CreateAccountResponse>(account);

            return accountResponse;
        }
    }
}
