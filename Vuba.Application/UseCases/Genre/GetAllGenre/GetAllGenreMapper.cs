using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Genre.GetAllGenre
{
    public sealed class GetAllGenreMapper : AutoMapper.Profile
    {
        public GetAllGenreMapper()
        {
            CreateMap<Domain.Entities.Genre, GetAllGenreResponse>();
        }
    }
}
