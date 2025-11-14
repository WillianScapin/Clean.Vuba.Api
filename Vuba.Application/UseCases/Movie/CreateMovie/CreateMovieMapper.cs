using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Movie.CreateMovie
{
    public sealed class CreateMovieMapper : AutoMapper.Profile
    {
        public CreateMovieMapper()
        {
            CreateMap<CreateMovieRequest, Domain.Entities.Movie>();
            CreateMap<Domain.Entities.Movie, CreateMovieResponse>();
        }
    }
}
