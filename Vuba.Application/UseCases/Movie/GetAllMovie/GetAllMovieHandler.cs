using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuba.Domain.Interfaces;

namespace Vuba.Application.UseCases.Movie.GetAllMovie
{
    public sealed class GetAllMovieHandler : IRequestHandler<GetAllMovieRequest, List<GetAllMovieResponse>>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public GetAllMovieHandler(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllMovieResponse>> Handle(GetAllMovieRequest request, CancellationToken cancellationToken)
        {
            var movie = await _movieRepository.GetAll(cancellationToken);
            return _mapper.Map<List<GetAllMovieResponse>>(movie);
        }
    }
}
