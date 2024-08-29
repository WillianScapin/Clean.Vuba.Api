using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Genre.DeleteGenre
{
    public sealed class DeleteGenreMapper : AutoMapper.Profile
    {
        public DeleteGenreMapper()
        {
            CreateMap<DeleteGenreRequest, Domain.Entities.Genre>();
            CreateMap<Domain.Entities.Genre, DeleteGenreResponse>();
        }
    }
}
