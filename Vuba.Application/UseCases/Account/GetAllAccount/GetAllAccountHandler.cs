using AutoMapper;
using MediatR;
using Vuba.Domain.Interfaces;

namespace Vuba.Application.UseCases.Account.GetAllAccount
{
    public sealed class GetAllAccountHandler : IRequestHandler<GetAllAccountRequest, List<GetAllAccountResponse>>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public GetAllAccountHandler(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        async Task<List<GetAllAccountResponse>> IRequestHandler<GetAllAccountRequest, List<GetAllAccountResponse>>.Handle(GetAllAccountRequest request, CancellationToken cancellationToken)
        {
            var accounts = await _accountRepository.GetAll(cancellationToken);
            return _mapper.Map<List<GetAllAccountResponse>>(accounts);
        }
    }
}
