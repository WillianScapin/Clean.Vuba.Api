using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuba.Domain.Interfaces;

namespace Vuba.Application.UseCases.Episode.DeleteEpisode
{
    public sealed class DeleteEpisodeHandler : IRequestHandler<DeleteEpisodeRequest, DeleteEpisodeResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEpisodeRepository _episodeRepository;
        private readonly IMapper _mapper;

        public DeleteEpisodeHandler(IUnitOfWork unitOfWork, IEpisodeRepository episodeRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _episodeRepository = episodeRepository;
            _mapper = mapper;
        }

        public async Task<DeleteEpisodeResponse> Handle(DeleteEpisodeRequest request, CancellationToken cancellationToken)
        {
            var episode = await _episodeRepository.Get(request.Id, cancellationToken);

            if (episode == null) return default;

            _episodeRepository.Delete(episode);
            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<DeleteEpisodeResponse>(episode);
        }
    }
}
