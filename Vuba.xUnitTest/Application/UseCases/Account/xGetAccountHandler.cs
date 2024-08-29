using AutoMapper;
using Vuba.Application.UseCases.Account.GetAccount;
using Vuba.Domain.Interfaces;
using Vuba.xUnitTest.Fixtures;

namespace Vuba.xUnitTest.Application.UseCases.Account
{
    public class xGetAccountHandler : IClassFixture<AutoMapperFixture>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public xGetAccountHandler(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public GetAccountResponse Handle(GetAccountRequest request, CancellationToken cancellationToken)
        {
            var account = _accountRepository.Get(request.id, cancellationToken).Result;

            //var account = new Vuba.Domain.Entities.Account()
            //{
            //    Id = 1,
            //    DateCreated = DateTime.UtcNow.AddDays(-1),
            //    DateDeleted = null,
            //    DateUpdated = null,
            //    Username = "Willian Scapin",
            //    Email = "WillianScapin@gmail.com",
            //    Password = "-Mda8960!@#",
            //    profiles = null
            //};

            return _mapper.Map<GetAccountResponse>(account);
        }
    }
}
