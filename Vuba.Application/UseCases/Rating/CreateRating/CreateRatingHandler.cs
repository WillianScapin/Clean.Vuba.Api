using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Vuba.Domain.Interfaces;

namespace Vuba.Application.UseCases.Rating.CreateRating
{
    public sealed class CreateRatingHandler : IRequestHandler<CreateRatingRequest, CreateRatingResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRatingRepository _ratingRepository;
        private readonly IMapper _mapper;

        public CreateRatingHandler(IUnitOfWork unitOfWork, IRatingRepository ratingRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _ratingRepository = ratingRepository;
            _mapper = mapper;
        }

        public async Task<CreateRatingResponse> Handle(CreateRatingRequest request, CancellationToken cancellationToken)
        {
            var rating = _mapper.Map<Domain.Entities.Rating>(request);

            _ratingRepository.Create(rating);
            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<CreateRatingResponse>(rating);
        }
    }
}
