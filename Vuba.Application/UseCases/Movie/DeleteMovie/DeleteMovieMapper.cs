using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Movie.DeleteMovie
{
    public sealed class DeleteMovieMapper : AutoMapper.Profile
    {
        public DeleteMovieMapper() 
        {
            CreateMap<DeleteMovieRequest, Domain.Entities.Movie>();
            CreateMap<Domain.Entities.Movie, DeleteMovieResponse>();
        }
    }
}
