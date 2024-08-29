using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Level.UpdateLevel
{
    public sealed class UpdateLevelMapper : AutoMapper.Profile
    {
        public UpdateLevelMapper()
        {
            CreateMap<UpdateLevelRequest, Domain.Entities.Level>();
            CreateMap<Domain.Entities.Level, UpdateLevelResponse>();
        }
    }
}
