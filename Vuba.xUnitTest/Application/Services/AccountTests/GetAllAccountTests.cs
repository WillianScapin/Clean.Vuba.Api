using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuba.Application.UseCases.Account.GetAccount;
using Vuba.Application.UseCases.Account.GetAllAccount;
using Vuba.Domain.Interfaces;
using Vuba.xUnitTest.Application.UseCases.Account;
using Vuba.xUnitTest.Fixtures;

namespace Vuba.xUnitTest.Application.Services.AccountTests
{
    public class GetAllAccountTests : IClassFixture<AutoMapperFixture>
    {
        private readonly IMapper _mapper;
        public GetAllAccountTests(AutoMapperFixture fixture)
        {
            _mapper = fixture.Mapper;
        }

        [Fact]
        public void ValidAccount_GetAllIsCalled_ReturnValidAccountResponse()
        {
            var cancellationToken = new CancellationToken(false);

            var request = new GetAllAccountRequest();
            var accountMoq = new Mock<IAccountRepository>();

            var xGetAllAccounthandler = new xGetAllAccountHandler(accountMoq.Object, _mapper);
            var response = xGetAllAccounthandler.Handle(request, cancellationToken);

            Assert.Equal(typeof(GetAllAccountRequest), request.GetType());

            accountMoq.Verify(am => am.GetAll(cancellationToken), Times.Once);
        }
    }
}
