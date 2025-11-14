using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Genre.GetGenre
{
    public sealed class GetGenreMapper : AutoMapper.Profile
    {
        public GetGenreMapper()
        {
            CreateMap<GetGenreRequest, Domain.Entities.Genre>();
            CreateMap<Domain.Entities.Genre, GetGenreResponse>();
        }
    }
}
