using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuba.Domain.Interfaces;

namespace Vuba.Application.UseCases.Serie.GetAllSerie
{
    public sealed class GetAllSerieHandler : IRequestHandler<GetAllSerieRequest, List<GetAllSerieResponse>>
    {
        private readonly ISeriesRepository _seriesRepository;
        private readonly IMapper _mapper;

        public GetAllSerieHandler(ISeriesRepository seriesRepository, IMapper mapper)
        {
            _seriesRepository = seriesRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllSerieResponse>> Handle(GetAllSerieRequest request, CancellationToken cancellationToken)
        {
            var series = await _seriesRepository.GetAll(cancellationToken);
            return _mapper.Map<List<GetAllSerieResponse>>(series);
        }
    }
}
