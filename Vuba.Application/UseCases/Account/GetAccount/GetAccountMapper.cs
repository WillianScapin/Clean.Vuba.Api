using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Account.GetAccount
{
    public sealed class GetAccountMapper : AutoMapper.Profile
    {
        public GetAccountMapper()
        {
            CreateMap<GetAccountRequest, Domain.Entities.Account>();
            CreateMap<Domain.Entities.Account, GetAccountResponse>();
        }
    }
}
