using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuba.Domain.Interfaces;

namespace Vuba.Application.UseCases.Serie.GetSerie
{
    public sealed class GetSerieHandler : IRequestHandler<GetSerieRequest, GetSerieResponse>
    {
        private ISeriesRepository _seriesRepository;
        private IMapper _mapper;

        public GetSerieHandler(ISeriesRepository seriesRepository, IMapper mapper)
        {
            _seriesRepository = seriesRepository;
            _mapper = mapper;
        }

        public async Task<GetSerieResponse> Handle(GetSerieRequest request, CancellationToken cancellationToken)
        {
            var serie = await _seriesRepository.Get(request.Id, cancellationToken);
            return _mapper.Map<GetSerieResponse>(serie);
        }
    }
}
