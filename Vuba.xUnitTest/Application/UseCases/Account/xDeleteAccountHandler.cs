using AutoMapper;
using System.Threading;
using Vuba.Application.UseCases.Account.DeleteAccount;
using Vuba.Domain.Interfaces;
using Vuba.xUnitTest.Fixtures;

namespace Vuba.xUnitTest.Application.UseCases.Account
{
    public class xDeleteAccountHandler : IClassFixture<AutoMapperFixture>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public xDeleteAccountHandler(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public DeleteAccountResponse Handle(DeleteAccountRequest request, CancellationToken cancellationToken)
        {
            var account = _accountRepository.Get(request.id, cancellationToken).Result;
            _accountRepository.Delete(account);
            return _mapper.Map<DeleteAccountResponse>(account);
        }
    }
}
