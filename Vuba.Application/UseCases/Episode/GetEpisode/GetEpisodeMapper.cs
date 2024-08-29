using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Episode.GetEpisode
{
    public sealed class GetEpisodeMapper : AutoMapper.Profile
    {
        public GetEpisodeMapper()
        {
            CreateMap<GetEpisodeRequest, Domain.Entities.Episode>();
            CreateMap<Domain.Entities.Episode, GetEpisodeResponse>();
        }
    }
}
