using AutoMapper;
using MediatR;
using Vuba.Domain.Interfaces;

namespace Vuba.Application.UseCases.Episode.CreateEpisode
{
    public sealed class CreateEpisodeHandler : IRequestHandler<CreateEpisodeRequest, CreateEpisodeResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEpisodeRepository _episodeRepository;
        private readonly IMapper _mapper;
        private readonly IAwsUploadReposotory _awsUpload;

        public CreateEpisodeHandler(IUnitOfWork unitOfWork, IEpisodeRepository episodeRepository, IMapper mapper, IAwsUploadReposotory awsUpload)
        {
            _unitOfWork = unitOfWork;
            _episodeRepository = episodeRepository;
            _mapper = mapper;
            _awsUpload = awsUpload;
        }

        public async Task<CreateEpisodeResponse> Handle(CreateEpisodeRequest request, CancellationToken cancellationToken)
        {
            var episode = _mapper.Map<Domain.Entities.Episode>(request);
            var uploadResponse = await _awsUpload.UploadFileAsync(request.EpisodeFile);

            episode.FileKey = uploadResponse.FileKey;
            episode.SerieUrl = uploadResponse.Url;

            var uploadThumbResponse = await _awsUpload.UploadFileAsync(request.ThumbFile);

            episode.ThumbUrl = uploadThumbResponse.Url;

            _episodeRepository.Create(episode);
            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<CreateEpisodeResponse>(episode);
        }
    }
}
