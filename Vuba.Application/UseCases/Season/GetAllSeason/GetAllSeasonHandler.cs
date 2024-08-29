using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuba.Domain.Interfaces;

namespace Vuba.Application.UseCases.Season.GetAllSeason
{
    public sealed class GetAllSeasonHandler : IRequestHandler<GetAllSeasonRequest, List<GetAllSeasonResponse>>
    {
        private readonly ISeasonRepository _seasonRepository;
        private readonly IMapper _mapper;

        public GetAllSeasonHandler(ISeasonRepository seasonRepository, IMapper mapper)
        {
            _seasonRepository = seasonRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllSeasonResponse>> Handle(GetAllSeasonRequest request, CancellationToken cancellationToken)
        {
            var seasons = await _seasonRepository.GetAll(cancellationToken);
            return _mapper.Map<List<GetAllSeasonResponse>>(seasons);
        }
    }
}
