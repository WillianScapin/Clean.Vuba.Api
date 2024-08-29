using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuba.Domain.Interfaces;

namespace Vuba.Application.UseCases.Movie.UpdateMovie
{
    public sealed class UpdateMovieHandler : IRequestHandler<UpdateMovieRequest, UpdateMovieResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;
        private readonly IAwsUploadReposotory _awsUpload;

        public UpdateMovieHandler(IUnitOfWork unitOfWork, IMovieRepository movieRepository, IMapper mapper, IAwsUploadReposotory awsUpload)
        {
            _unitOfWork = unitOfWork;
            _movieRepository = movieRepository;
            _mapper = mapper;
            _awsUpload = awsUpload;
        }

        public async Task<UpdateMovieResponse> Handle(UpdateMovieRequest request, CancellationToken cancellationToken)
        {
            var movie = await _movieRepository.Get(request.Id, cancellationToken);
            if (movie == null) return default;

            if (request.MovieFile != null)
            {
                var awsMovieUpload = await _awsUpload.UploadFileAsync(request.MovieFile);
                movie.MovieUrl = awsMovieUpload.Url;
                movie.FileKey = awsMovieUpload.FileKey;
            }

            if (request.MovieFile != null)
            {
                var awsThumbUpload = await _awsUpload.UploadFileAsync(request.MovieFile);
                movie.ThumbUrl = awsThumbUpload.Url;
            }



            movie.Title = request.Title;
            movie.Synopsis = request.Synopsis;
            movie.ReleaseYear = request.ReleaseYear;
            movie.AgeGroup = request.AgeGroup;
            movie.Director = request.Director;
            movie.Duration = request.Duration;

            _movieRepository.Update(movie);
            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<UpdateMovieResponse>(movie);
        }
    }
}
