using AutoMapper;
using Vuba.Application.UseCases.Account.CreateAccount;
using Vuba.Domain.Interfaces;
using Vuba.xUnitTest.Fixtures;

namespace Vuba.xUnitTest.Application.UseCases.Account
{
    public class xCreateAccountHandler : IClassFixture<AutoMapperFixture>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public xCreateAccountHandler(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public CreateAccountResponse Handle(CreateAccountRequest request)
        {
            var account = _mapper.Map<Domain.Entities.Account>(request);
            _accountRepository.Create(account);
            return _mapper.Map<CreateAccountResponse>(account);
        }
    }
}
