using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuba.Domain.Interfaces;

namespace Vuba.Application.UseCases.Episode.GetEpisode
{
    public sealed class GetEpisodeHandler : IRequestHandler<GetEpisodeRequest, GetEpisodeResponse>
    {
        private readonly IEpisodeRepository _episodeRepository;
        private readonly IMapper _mapper;

        public GetEpisodeHandler(IEpisodeRepository episodeRepository, IMapper mapper)
        {
            _episodeRepository = episodeRepository;
            _mapper = mapper;
        }

        public async Task<GetEpisodeResponse> Handle(GetEpisodeRequest request, CancellationToken cancellationToken)
        {
            var episode = await _episodeRepository.Get(request.Id, cancellationToken);
            return _mapper.Map<GetEpisodeResponse>(episode);
        }
    }
}
