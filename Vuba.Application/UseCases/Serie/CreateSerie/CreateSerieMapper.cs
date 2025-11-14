using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Serie.CreateSerie
{
    public sealed class CreateSerieMapper : AutoMapper.Profile
    {
        public CreateSerieMapper()
        {
            CreateMap<CreateSerieRequest, Domain.Entities.Serie>();
            CreateMap<Domain.Entities.Serie, CreateSerieResponse>();
        }
    }
}
