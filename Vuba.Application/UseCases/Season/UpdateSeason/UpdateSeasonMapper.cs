using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Season.UpdateSeason
{
    public sealed class UpdateSeasonMapper : AutoMapper.Profile
    {
        public UpdateSeasonMapper()
        {
            CreateMap<UpdateSeasonRequest, Domain.Entities.Season>();
            CreateMap<Domain.Entities.Season, UpdateSeasonResponse>();
        }
    }
}
