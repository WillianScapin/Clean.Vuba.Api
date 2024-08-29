using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Level.GetLevel
{
    public sealed class GetLevelMapper : AutoMapper.Profile
    {
        public GetLevelMapper()
        {
            CreateMap<GetLevelRequest, Domain.Entities.Level>();
            CreateMap<Domain.Entities.Level, GetLevelResponse>();
        }
    }
}
