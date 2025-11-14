using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuba.Domain.Interfaces;

namespace Vuba.Application.UseCases.Episode.UpdateEpisode
{
    public sealed class UpdateEpisodeHandler : IRequestHandler<UpdateEpisodeRequest, UpdateEpisodeResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEpisodeRepository _episodeRepository;
        private readonly IMapper _mapper;
        private readonly IAwsUploadReposotory _awsUpload;

        public UpdateEpisodeHandler(IUnitOfWork unitOfWork, IEpisodeRepository episodeRepository, IMapper mapper, IAwsUploadReposotory awsUpload)
        {
            _unitOfWork = unitOfWork;
            _episodeRepository = episodeRepository;
            _mapper = mapper;
            _awsUpload = awsUpload;
        }

        public async Task<UpdateEpisodeResponse> Handle(UpdateEpisodeRequest request, CancellationToken cancellationToken)
        {
            _mapper.Map<Domain.Entities.Episode>(request);

            var episode = await _episodeRepository.Get(request.Id, cancellationToken);
            if (episode == null) return default;

            if (request.EpisodeFile != null)
            {
                var uploadResponse = await _awsUpload.UploadFileAsync(request.EpisodeFile);

                episode.FileKey = uploadResponse.FileKey;
                episode.SerieUrl = uploadResponse.Url;
            }

            if (request.ThumbFile != null)
            {
                var uploadThumbResponse = await _awsUpload.UploadFileAsync(request.ThumbFile);
                episode.ThumbUrl = uploadThumbResponse.Url;
            }


            episode.Duration = request.Duration;
            episode.EpisodeNumber = request.EpisodeNumber;
            episode.Title = request.Title;
            episode.ReleaseDate = request.ReleaseDate;
            episode.Synopsis = request.Synopsis;

            _episodeRepository.Update(episode);

            await _unitOfWork.Commit(cancellationToken);
            return _mapper.Map<UpdateEpisodeResponse>(episode);
        }
    }
}
