using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Level.DeleteLevel
{
    public sealed class DeleteLevelMapper : AutoMapper.Profile
    {
        public DeleteLevelMapper()
        {
            CreateMap<DeleteLevelRequest, Domain.Entities.Level>();
            CreateMap<Domain.Entities.Level, DeleteLevelResponse>();
        }
    }
}
