using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Vuba.Domain.Entities;
using Vuba.Domain.Interfaces;

namespace Vuba.Application.UseCases.Rating.UpdateRating
{
    public sealed class UpdateRatingHandler : IRequestHandler<UpdateRatingRequest, UpdateRatingResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRatingRepository _ratingRepository;
        private readonly IMapper _mapper;

        public UpdateRatingHandler(IUnitOfWork unitOfWork, IRatingRepository ratingRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _ratingRepository = ratingRepository;
            _mapper = mapper;
        }

        public async Task<UpdateRatingResponse> Handle(UpdateRatingRequest request, CancellationToken cancellationToken)
        {
            var rating = await _ratingRepository.Get(request.Id, cancellationToken);
            if (rating == null) return default;

            rating.ContentId = request.ContentId;
            rating.ContentType = request.ContentType;
            rating.UserId = request.UserId;
            rating.Score = request.Score;
            rating.Timestamp = request.Timestamp;

            _ratingRepository.Update(rating);
            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<UpdateRatingResponse>(rating);

        }
    }
}
