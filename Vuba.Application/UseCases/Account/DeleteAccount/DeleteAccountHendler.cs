using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuba.Domain.Interfaces;

namespace Vuba.Application.UseCases.Account.DeleteAccount
{
    public sealed class DeleteAccountHendler : IRequestHandler<DeleteAccountRequest, DeleteAccountResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public DeleteAccountHendler(IUnitOfWork unitOfWork, IAccountRepository accountRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public async Task<DeleteAccountResponse> Handle(DeleteAccountRequest request, CancellationToken cancellationToken)
        {
            var account = await _accountRepository.Get(request.id, cancellationToken);

            if (account == null) return default;

            _accountRepository.Delete(account);
            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<DeleteAccountResponse>(request);
        }
    }
}
