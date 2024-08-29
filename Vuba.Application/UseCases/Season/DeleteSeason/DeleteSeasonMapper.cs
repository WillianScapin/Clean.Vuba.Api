using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Season.DeleteSeason
{
    public sealed class DeleteSeasonMapper : AutoMapper.Profile
    {
        public DeleteSeasonMapper()
        {
            CreateMap<DeleteSeasonRequest, Domain.Entities.Season>();
            CreateMap<Domain.Entities.Season, DeleteSeasonResponse>();
        }
    }
}
