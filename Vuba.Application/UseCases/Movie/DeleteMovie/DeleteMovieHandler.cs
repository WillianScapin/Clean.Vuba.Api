using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuba.Domain.Interfaces;

namespace Vuba.Application.UseCases.Movie.DeleteMovie
{
    public sealed class DeleteMovieHandler : IRequestHandler<DeleteMovieRequest, DeleteMovieResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public DeleteMovieHandler(IUnitOfWork unitOfWork, IMovieRepository movieRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<DeleteMovieResponse> Handle(DeleteMovieRequest request, CancellationToken cancellationToken)
        {
            var movie = await _movieRepository.Get(request.Id, cancellationToken);
            if (movie == null) return default;

            _movieRepository.Delete(movie);
            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<DeleteMovieResponse>(movie);
        }
    }
}
