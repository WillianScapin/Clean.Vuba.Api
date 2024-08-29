using AutoMapper;
using Moq;
using System.Threading;
using Vuba.Application.UseCases.Account.GetAccount;
using Vuba.Domain.Entities;
using Vuba.Domain.Interfaces;
using Vuba.xUnitTest.Application.UseCases.Account;
using Vuba.xUnitTest.Fixtures;

namespace Vuba.xUnitTest.Application.Services.AccountTests
{
    public class GetAccountTests : IClassFixture<AutoMapperFixture>
    {
        private readonly IMapper _mapper;
        public GetAccountTests(AutoMapperFixture fixture)
        {
            _mapper = fixture.Mapper;
        }

        [Fact]
        public void ValidAccount_GetIsCalled_ReturnValidAccountResponse()
        {
            var cancellationToken = new CancellationToken(false);

            var request = new GetAccountRequest(1);
            var accountMoq = new Mock<IAccountRepository>();

            var xGetAccounthandler = new xGetAccountHandler(accountMoq.Object, _mapper);
            var response = xGetAccounthandler.Handle(request, cancellationToken);

            Assert.Equal(1, request.id);

            accountMoq.Verify(am => am.Get(It.IsAny<int>(), cancellationToken), Times.Once);
        }
    }
}
