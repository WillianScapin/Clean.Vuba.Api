using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Movie.UpdateMovie
{
    public sealed class UpdateMovieMapper : AutoMapper.Profile
    {
        public UpdateMovieMapper() 
        {
            CreateMap<UpdateMovieRequest, Domain.Entities.Movie>();
            CreateMap<Domain.Entities.Movie, UpdateMovieResponse>();
        }
    }
}
