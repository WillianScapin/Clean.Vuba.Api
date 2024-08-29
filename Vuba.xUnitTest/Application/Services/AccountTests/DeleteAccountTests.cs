using AutoMapper;
using Moq;
using Vuba.Application.UseCases.Account.DeleteAccount;
using Vuba.Domain.Entities;
using Vuba.Domain.Interfaces;
using Vuba.xUnitTest.Application.UseCases.Account;
using Vuba.xUnitTest.Fixtures;

namespace Vuba.xUnitTest.Application.Services.AccountTests
{
    public class DeleteAccountTests : IClassFixture<AutoMapperFixture>
    {
        private readonly IMapper _mapper;
        public DeleteAccountTests(AutoMapperFixture fixture)
        {
            _mapper = fixture.Mapper;
        }

        [Fact]
        public void ValidAccount_DeleteIsCalled_ReturnValidAccountResponse()
        {
            var request = new DeleteAccountRequest(1);
            var accountMoq = new Mock<IAccountRepository>();

            var xDeleteAccounthandler = new xDeleteAccountHandler(accountMoq.Object, _mapper);
            var response = xDeleteAccounthandler.Handle(request, new CancellationToken(false));

            Assert.Equal(request.id, 1);

            accountMoq.Verify(am => am.Delete(It.IsAny<Account>()), Times.Once);
        }
    }
}
