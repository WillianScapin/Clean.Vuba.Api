using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuba.Domain.Interfaces;

namespace Vuba.Application.UseCases.Rating.GetRating
{
    public sealed class GetRatingHandler : IRequestHandler<GetRatingRequest, GetRatingResponse>
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly IMapper _mapper;

        public GetRatingHandler(IRatingRepository ratingRepository, IMapper mapper)
        {
            _ratingRepository = ratingRepository;
            _mapper = mapper;
        }

        public async Task<GetRatingResponse> Handle(GetRatingRequest request, CancellationToken cancellationToken)
        {
            var rating = await _ratingRepository.Get(request.Id, cancellationToken);
            return _mapper.Map<GetRatingResponse>(rating);
        }
    }
}
