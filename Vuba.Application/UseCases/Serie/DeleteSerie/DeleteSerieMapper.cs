using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Serie.DeleteSerie
{
    public sealed class DeleteSerieMapper : AutoMapper.Profile
    {
        public DeleteSerieMapper()
        {
            CreateMap<DeleteSerieRequest, Domain.Entities.Serie>();
            CreateMap<Domain.Entities.Serie, DeleteSerieResponse>();
        }
    }
}
