using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Serie.GetSerie
{
    public sealed class GetSerieMapper : AutoMapper.Profile
    {
        public GetSerieMapper() 
        {
            CreateMap<GetSerieRequest, Domain.Entities.Serie>();
            CreateMap<Domain.Entities.Serie, GetSerieResponse>();
        }
    }
}
