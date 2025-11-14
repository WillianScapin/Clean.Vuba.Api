using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Episode.CreateEpisode
{
    public sealed class CreateEpisodeMapper : AutoMapper.Profile
    {
        public CreateEpisodeMapper()
        {
            CreateMap<CreateEpisodeRequest, Domain.Entities.Episode>();
            CreateMap<Domain.Entities.Episode, CreateEpisodeResponse>();
        }
    }
}
