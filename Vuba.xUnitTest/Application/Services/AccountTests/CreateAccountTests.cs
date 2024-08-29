using AutoMapper;
using Moq;
using Vuba.Application.UseCases.Account.CreateAccount;
using Vuba.Domain.Entities;
using Vuba.Domain.Interfaces;
using Vuba.xUnitTest.Application.UseCases.Account;
using Vuba.xUnitTest.Fixtures;

namespace Vuba.xUnitTest.Application.Services.AccountTests
{
    public class CreateAccountTests : IClassFixture<AutoMapperFixture>
    {
        private readonly IMapper _mapper;
        public CreateAccountTests(AutoMapperFixture fixture)
        {
            _mapper = fixture.Mapper;
        }

        [Fact]
        public void ValidAccount_CreateIsCalled_ReturnValidAccountResponse()
        {
            var request = new CreateAccountRequest("Willian Scapin", "scapinwill@gmail.com", "-Mda8960!@#");
            var accountMoq = new Mock<IAccountRepository>();

            var xCreateAccountHandler = new xCreateAccountHandler(accountMoq.Object, _mapper);
            var response = xCreateAccountHandler.Handle(request);

            Assert.Equal(request.username, response.Username);
            Assert.Equal(request.email, response.Email);

            accountMoq.Verify(am => am.Create(It.IsAny<Account>()), Times.Once);
        }
    }
}
