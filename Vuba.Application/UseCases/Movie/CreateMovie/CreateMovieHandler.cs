using AutoMapper;
using MediatR;
using Vuba.Domain.Interfaces;

namespace Vuba.Application.UseCases.Movie.CreateMovie
{
    public sealed class CreateMovieHandler : IRequestHandler<CreateMovieRequest, CreateMovieResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;
        private readonly IAwsUploadReposotory _awsUpload;

        public CreateMovieHandler(IUnitOfWork unitOfWork, IMovieRepository movieRepository, IMapper mapper, IAwsUploadReposotory awsUpload)
        {
            _unitOfWork = unitOfWork;
            _movieRepository = movieRepository;
            _mapper = mapper;
            _awsUpload = awsUpload;
        }

        public async Task<CreateMovieResponse> Handle(CreateMovieRequest request, CancellationToken cancellationToken)
        {
            var movie = _mapper.Map<Domain.Entities.Movie>(request);

            var awsMovieUpload = await _awsUpload.UploadFileAsync(request.MovieFile);
            movie.MovieUrl = awsMovieUpload.Url;
            movie.FileKey = awsMovieUpload.FileKey;

            var awsThumbUpload = await _awsUpload.UploadFileAsync(request.MovieFile);
            movie.ThumbUrl = awsThumbUpload.Url;


            _movieRepository.Create(movie);
            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<CreateMovieResponse>(movie);
        }
    }
}
