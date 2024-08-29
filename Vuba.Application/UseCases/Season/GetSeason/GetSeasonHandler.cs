using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuba.Domain.Interfaces;

namespace Vuba.Application.UseCases.Season.GetSeason
{
    public sealed class GetSeasonHandler : IRequestHandler<GetSeasonRequest, GetSeasonResponse>
    {
        private readonly ISeasonRepository _seasonRepository;
        private readonly IMapper _mapper;

        public GetSeasonHandler(ISeasonRepository seasonRepository, IMapper mapper)
        {
            _seasonRepository = seasonRepository;
            _mapper = mapper;
        }

        public async Task<GetSeasonResponse> Handle(GetSeasonRequest request, CancellationToken cancellationToken)
        {
            var season = await _seasonRepository.Get(request.Id, cancellationToken);
            return _mapper.Map<GetSeasonResponse>(season);
        }
    }
}
