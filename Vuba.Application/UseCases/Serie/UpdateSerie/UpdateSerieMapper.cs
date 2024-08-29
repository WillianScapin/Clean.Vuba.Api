using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Serie.UpdateSerie
{
    public sealed class UpdateSerieMapper : AutoMapper.Profile
    {
        public UpdateSerieMapper() 
        {
            CreateMap<UpdateSerieRequest, Domain.Entities.Serie>();
            CreateMap<Domain.Entities.Serie, UpdateSerieResponse>();
        }
    }
}
