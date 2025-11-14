using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuba.Domain.Interfaces;

namespace Vuba.Application.UseCases.Genre.GetGenre
{
    public sealed class GetGenreHandler : IRequestHandler<GetGenreRequest, GetGenreResponse>
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public GetGenreHandler(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public async Task<GetGenreResponse> Handle(GetGenreRequest request, CancellationToken cancellationToken)
        {
            var genre = await _genreRepository.Get(request.Id, cancellationToken);
            return _mapper.Map<GetGenreResponse>(genre);
        }
    }
}
