using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuba.Application.UseCases.Movie.GetMovie;
using Vuba.Domain.Entities;
using Vuba.Domain.Interfaces;

namespace Vuba.Application.UseCases.Media.GetAllMedia
{
    public sealed class GetMediaHandler : IRequestHandler<GetMediaRequest, GetMediaResponse>
    {
        private readonly IMediaRepository _mediaRepository;
        private readonly IMapper _mapper;

        public GetMediaHandler(IMediaRepository mediaRepository, IMapper mapper)
        {
            _mediaRepository = mediaRepository;
            _mapper = mapper;
        }

        public async Task<GetMediaResponse> Handle(GetMediaRequest request, CancellationToken cancellationToken)
        {
            var medias = _mediaRepository.GetMedias(request.genreCount, request.itensPerGenre);
            return _mapper.Map<GetMediaResponse>(medias);
        }
    }
}
