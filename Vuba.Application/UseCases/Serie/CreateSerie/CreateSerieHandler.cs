using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuba.Domain.Interfaces;

namespace Vuba.Application.UseCases.Serie.CreateSerie
{
    public sealed class CreateSerieHandler : IRequestHandler<CreateSerieRequest, CreateSerieResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISeriesRepository _seriesRepository;
        private readonly IMapper _mapper;

        public CreateSerieHandler(IUnitOfWork unitOfWork, ISeriesRepository seriesRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _seriesRepository = seriesRepository;
            _mapper = mapper;
        }

        public async Task<CreateSerieResponse> Handle(CreateSerieRequest request, CancellationToken cancellationToken)
        {
            var serie = _mapper.Map<Domain.Entities.Serie>(request);

            _seriesRepository.Create(serie);
            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<CreateSerieResponse>(serie);
        }
    }
}
