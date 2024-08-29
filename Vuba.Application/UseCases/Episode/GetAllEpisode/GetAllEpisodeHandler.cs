using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuba.Domain.Interfaces;

namespace Vuba.Application.UseCases.Episode.GetAllEpisode
{
    public sealed class GetAllEpisodeHandler : IRequestHandler<GetAllEpisodeRequest, List<GetAllEpisodeResponse>>
    {
        private readonly IEpisodeRepository _episodeRepository;
        private readonly IMapper _mapper;

        public GetAllEpisodeHandler(IEpisodeRepository episodeRepository, IMapper mapper)
        {
            _episodeRepository = episodeRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllEpisodeResponse>> Handle(GetAllEpisodeRequest request, CancellationToken cancellationToken)
        {
            var episodes = await _episodeRepository.GetAll(cancellationToken);
            return _mapper.Map<List<GetAllEpisodeResponse>>(episodes);
        }
    }
}
