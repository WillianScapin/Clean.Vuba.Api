using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuba.Application.UseCases.Account.GetAllAccount;
using Vuba.Application.UseCases.Account.UpdateAccount;
using Vuba.Domain.Entities;
using Vuba.Domain.Interfaces;
using Vuba.xUnitTest.Application.UseCases.Account;
using Vuba.xUnitTest.Fixtures;

namespace Vuba.xUnitTest.Application.Services.AccountTests
{
    public class UpdateAccountTests : IClassFixture<AutoMapperFixture>
    {
        private readonly IMapper _mapper;
        public UpdateAccountTests(AutoMapperFixture fixture)
        {
            _mapper = fixture.Mapper;
        }

        [Fact]
        public void ValidAccount_UpdateIsCalled_ReturnValidAccountResponse()
        {
            var cancellationToken = new CancellationToken(false);

            var request = new UpdateAccountRequest(1, "Willian", "-Master!@#456", "scapinwill@gmail.com");
            var accountMoq = new Mock<IAccountRepository>();

            var xUpdateAccounthandler = new xUpdateAccountHandler(accountMoq.Object, _mapper);
            var response = xUpdateAccounthandler.Handle(request, cancellationToken);

            Assert.Equal(response.Id, request.id);
            Assert.Equal(response.Username, request.username);
            Assert.Equal(response.Email, request.email);

            accountMoq.Verify(am => am.Update(It.IsAny<Account>()), Times.Once);
        }
    }
}
