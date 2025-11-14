using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vuba.Application.UseCases.Account.CreateAccount;
using Vuba.Application.UseCases.Account.UpdateAccount;
using Vuba.Application.UseCases.Account.UpdateUser;
using Vuba.Domain.Interfaces;
using Vuba.xUnitTest.Fixtures;

namespace Vuba.xUnitTest.Application.UseCases.Account
{
    public class xUpdateAccountHandler : IClassFixture<AutoMapperFixture>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public xUpdateAccountHandler(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public UpdateAccountResponse Handle(UpdateAccountRequest request, CancellationToken cancellationToken)
        {
            _mapper.Map<Domain.Entities.Account>(request);

            var account = new Domain.Entities.Account()
            {
                Id = request.id
            };

            account.Email = request.email;
            account.Password = request.password;
            account.Username = request.username;

            _accountRepository.Update(account);


            return _mapper.Map<UpdateAccountResponse>(account);
        }
    }
}
