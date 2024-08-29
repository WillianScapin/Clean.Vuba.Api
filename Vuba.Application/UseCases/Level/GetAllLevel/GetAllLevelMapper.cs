using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Level.GetAllLevel
{
    public sealed class GetAllLevelMapper : AutoMapper.Profile
    {
        public GetAllLevelMapper()
        {
            CreateMap<Domain.Entities.Level, GetAllLevelResponse>();
        }
    }
}
