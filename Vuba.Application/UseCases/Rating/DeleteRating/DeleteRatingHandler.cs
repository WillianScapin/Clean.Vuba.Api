using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuba.Domain.Interfaces;

namespace Vuba.Application.UseCases.Rating.DeleteRating
{
    public sealed class DeleteRatingHandler : IRequestHandler<DeleteRatingRequest, DeleteRatingResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRatingRepository _ratingRepository;
        private IMapper _mapper;

        public DeleteRatingHandler(IUnitOfWork unitOfWork, IRatingRepository ratingRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _ratingRepository = ratingRepository;
            _mapper = mapper;
        }

        public async Task<DeleteRatingResponse> Handle(DeleteRatingRequest request, CancellationToken cancellationToken)
        {
            var rating = await _ratingRepository.Get(request.Id, cancellationToken);

            _ratingRepository.Delete(rating);
            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<DeleteRatingResponse>(rating);
        }
    }
}
