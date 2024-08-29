using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Genre.UpdateGenre
{
    public sealed class UpdateGenreMapper : AutoMapper.Profile
    {
        public UpdateGenreMapper()
        {
            CreateMap<UpdateGenreRequest, Domain.Entities.Genre>();
            CreateMap<Domain.Entities.Genre, UpdateGenreResponse>();
        }
    }
}
