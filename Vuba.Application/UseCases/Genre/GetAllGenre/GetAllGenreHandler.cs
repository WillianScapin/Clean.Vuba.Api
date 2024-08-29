using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuba.Domain.Interfaces;

namespace Vuba.Application.UseCases.Genre.GetAllGenre
{
    public sealed class GetAllGenreHandler : IRequestHandler<GetAllGenreRequest, List<GetAllGenreResponse>>
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public GetAllGenreHandler(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllGenreResponse>> Handle(GetAllGenreRequest request, CancellationToken cancellationToken)
        {
            var genres = await _genreRepository.GetAll(cancellationToken);
            return _mapper.Map<List<GetAllGenreResponse>>(genres);
        }
    }
}
