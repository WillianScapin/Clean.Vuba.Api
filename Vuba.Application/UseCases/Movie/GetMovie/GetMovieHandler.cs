using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuba.Domain.Interfaces;

namespace Vuba.Application.UseCases.Movie.GetMovie
{
    public sealed class GetMovieHandler : IRequestHandler<GetMovieRequest, GetMovieResponse>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public GetMovieHandler(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<GetMovieResponse> Handle(GetMovieRequest request, CancellationToken cancellationToken)
        {
            var movie = await _movieRepository.Get(request.Id, cancellationToken);
            return _mapper.Map<GetMovieResponse>(movie);
        }
    }
}
