using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Season.GetAllSeason
{
    public sealed class GetAllSeasonMapper : AutoMapper.Profile
    {
        public GetAllSeasonMapper()
        {
            CreateMap<Domain.Entities.Season, GetAllSeasonResponse>();
        }
    }
}
