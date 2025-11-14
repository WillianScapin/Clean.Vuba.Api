using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuba.Application.UseCases.Account.UpdateUser;
using Vuba.Domain.Interfaces;

namespace Vuba.Application.UseCases.Account.UpdateAccount
{
    public sealed class UpdateAccountHandler : IRequestHandler<UpdateAccountRequest, UpdateAccountResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public UpdateAccountHandler(IUnitOfWork unitOfWork, IAccountRepository accountRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public async Task<UpdateAccountResponse> Handle(UpdateAccountRequest request, CancellationToken cancellationToken)
        {
            _mapper.Map<Domain.Entities.Account>(request);

            var account = await _accountRepository.Get(request.id, cancellationToken);
            if (account == null) return default;

            account.Email = request.email;
            account.Password = request.password;
            account.Username = request.username;

            _accountRepository.Update(account);

            await _unitOfWork.Commit(cancellationToken);
            return _mapper.Map<UpdateAccountResponse>(account);
        }
    }
}
