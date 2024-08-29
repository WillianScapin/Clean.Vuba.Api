using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Login.CreateLogin
{
    public sealed class CreateLoginMapper : AutoMapper.Profile
    {
        public CreateLoginMapper()
        {
            CreateMap<CreateLoginRequest, Domain.Entities.Login>();
            CreateMap<Domain.Entities.Login, CreateLoginResponse>();
        }
    }
}
