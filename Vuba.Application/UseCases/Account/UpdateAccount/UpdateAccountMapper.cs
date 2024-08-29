using AutoMapper;
using Vuba.Application.UseCases.Account.UpdateUser;

namespace Vuba.Application.UseCases.Account.UpdateAccount
{
    public sealed class UpdateAccountMapper : AutoMapper.Profile
    {
        public UpdateAccountMapper()
        {
            CreateMap<UpdateAccountRequest, Domain.Entities.Account>();
            CreateMap<Domain.Entities.Account, UpdateAccountResponse>();
        }
    }
}
