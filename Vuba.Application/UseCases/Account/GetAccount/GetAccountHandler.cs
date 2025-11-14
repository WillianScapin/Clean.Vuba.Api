using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuba.Domain.Interfaces;

namespace Vuba.Application.UseCases.Account.GetAccount
{
    public sealed class GetAccountHandler : IRequestHandler<GetAccountRequest, GetAccountResponse>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public GetAccountHandler(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public async Task<GetAccountResponse> Handle(GetAccountRequest request, CancellationToken cancellationToken)
        {
            var account = await _accountRepository.Get(request.id, cancellationToken);
            return _mapper.Map<GetAccountResponse>(account);
        }
    }
}
