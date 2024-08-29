using AutoMapper;
using Vuba.Domain.Entities;

namespace Vuba.Application.UseCases.Account.CreateAccount
{
    public sealed class CreateAccountMapper : AutoMapper.Profile
    {
        public CreateAccountMapper()
        {
            CreateMap<CreateAccountRequest, Domain.Entities.Account>();
            CreateMap<Domain.Entities.Account, CreateAccountResponse>();
        }
    }
}
