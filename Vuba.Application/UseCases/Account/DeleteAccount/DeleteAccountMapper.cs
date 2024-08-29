using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Account.DeleteAccount
{
    public sealed class DeleteAccountMapper : AutoMapper.Profile
    {
        public DeleteAccountMapper()
        {
            CreateMap<DeleteAccountRequest, Domain.Entities.Account>();
            CreateMap<Domain.Entities.Account, DeleteAccountResponse>();
        }
    }
}
