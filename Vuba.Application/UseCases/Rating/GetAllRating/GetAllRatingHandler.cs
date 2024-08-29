using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuba.Domain.Interfaces;

namespace Vuba.Application.UseCases.Rating.GetAllRating
{
    public sealed class GetAllRatingHandler : IRequestHandler<GetAllRatingRequest, List<GetAllRatingResponse>>
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly IMapper _mapper;

        public GetAllRatingHandler(IRatingRepository ratingRepository, IMapper mapper)
        {
            _ratingRepository = ratingRepository;
            _mapper = mapper;
        }

        public  async Task<List<GetAllRatingResponse>> Handle(GetAllRatingRequest request, CancellationToken cancellationToken)
        {
            var ratings = await  _ratingRepository.GetAll(cancellationToken);
            return _mapper.Map<List<GetAllRatingResponse>>(ratings);
        }
    }
}
