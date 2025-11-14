using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Episode.UpdateEpisode
{
    public sealed class UpdateEpisodeMapper : AutoMapper.Profile
    {
        public UpdateEpisodeMapper()
        {
            CreateMap<UpdateEpisodeRequest, Domain.Entities.Episode>();
            CreateMap<Domain.Entities.Episode, UpdateEpisodeResponse>();
        }
    }
}
