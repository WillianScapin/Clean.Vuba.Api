using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Movie.GetAllMovie
{
    public sealed class GetAllMovieMapper : AutoMapper.Profile
    {
        public GetAllMovieMapper()
        {
            CreateMap<Domain.Entities.Movie, GetAllMovieResponse>();
        }
    }
}
