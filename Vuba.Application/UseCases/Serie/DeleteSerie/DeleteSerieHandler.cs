using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuba.Domain.Interfaces;

namespace Vuba.Application.UseCases.Serie.DeleteSerie
{
    public sealed class DeleteSerieHandler : IRequestHandler<DeleteSerieRequest, DeleteSerieResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISeriesRepository _seriesRepository;
        private readonly IMapper _mapper;

        public DeleteSerieHandler(IUnitOfWork unitOfWork, ISeriesRepository seriesRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _seriesRepository = seriesRepository;
            _mapper = mapper;
        }

        public async Task<DeleteSerieResponse> Handle(DeleteSerieRequest request, CancellationToken cancellationToken)
        {
            var serie = await _seriesRepository.Get(request.Id, cancellationToken);
            if (serie == null) return default;

            _seriesRepository.Delete(serie);
            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<DeleteSerieResponse>(serie);
        }
    }
}
