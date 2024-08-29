using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuba.Application.UseCases.Account.GetAccount;
using Vuba.Application.UseCases.Account.GetAllAccount;
using Vuba.Domain.Interfaces;
using Vuba.xUnitTest.Fixtures;

namespace Vuba.xUnitTest.Application.UseCases.Account
{
    public class xGetAllAccountHandler : IClassFixture<AutoMapperFixture>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public xGetAllAccountHandler(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public List<GetAllAccountResponse> Handle(GetAllAccountRequest request, CancellationToken cancellationToken)
        {
            var account = _accountRepository.GetAll(cancellationToken).Result;
            return _mapper.Map<List<GetAllAccountResponse>>(account);
        }
    }
}
