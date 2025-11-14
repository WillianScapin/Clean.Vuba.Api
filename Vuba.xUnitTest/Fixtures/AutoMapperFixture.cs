using AutoMapper;
using Vuba.Application.UseCases.Account.CreateAccount;
using Vuba.Application.UseCases.Account.DeleteAccount;
using Vuba.Application.UseCases.Account.GetAccount;
using Vuba.Application.UseCases.Account.GetAllAccount;
using Vuba.Application.UseCases.Account.UpdateAccount;
using Vuba.Application.UseCases.Account.UpdateUser;
using Vuba.Domain.Entities;

namespace Vuba.xUnitTest.Fixtures
{
    public class AutoMapperFixture : IDisposable
    {
        public IMapper Mapper { get; private set; }

        public AutoMapperFixture()
        {
            var config = new MapperConfiguration(cfg =>
            {
                #region Account
                //Create Account
                cfg.CreateMap<CreateAccountRequest, Account>();
                cfg.CreateMap<Account, CreateAccountResponse>();


                //Delete Account
                cfg.CreateMap<DeleteAccountRequest, Account>();
                cfg.CreateMap<Account, DeleteAccountResponse>();

                cfg.CreateMap<GetAccountRequest, Account>();
                cfg.CreateMap<Account, GetAccountResponse>();

                //Get Account
                cfg.CreateMap<GetAccountRequest, Account>();
                cfg.CreateMap<Account, GetAccountResponse>();

                //GetAll Account
                cfg.CreateMap<Account, GetAllAccountResponse>();

                //Update Account
                cfg.CreateMap<UpdateAccountRequest, Account>();
                cfg.CreateMap<Account, UpdateAccountResponse>();

                #endregion

                #region Episode

                #endregion
            });

            Mapper = config.CreateMapper();
        }

        public void Dispose()
        {
            // Limpeza se necessário
        }
    }
}
