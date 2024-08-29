using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Season.GetSeason
{
    public sealed class GetSeasonMapper : AutoMapper.Profile
    {
        public GetSeasonMapper()
        {
            CreateMap<GetSeasonRequest, Domain.Entities.Season>();
            CreateMap<Domain.Entities.Season, GetSeasonResponse>();
        }
    }
}
