using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Serie.GetAllSerie
{
    public sealed class GetAllSerieMapper : AutoMapper.Profile
    {
        public GetAllSerieMapper()
        {
            CreateMap<Domain.Entities.Serie, GetAllSerieResponse>();
        }
    }
}
