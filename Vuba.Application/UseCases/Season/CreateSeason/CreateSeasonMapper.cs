using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Season.CreateSeason
{
    public sealed class CreateSeasonMapper : AutoMapper.Profile
    {
        public CreateSeasonMapper() 
        {
            CreateMap<CreateSeasonRequest, Domain.Entities.Season>();
            CreateMap<Domain.Entities.Season, CreateSeasonResponse>();
        }
    }
}
