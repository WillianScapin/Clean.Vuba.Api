using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuba.Domain.Entities;
using Vuba.Domain.Interfaces;

namespace Vuba.Application.UseCases.Serie.UpdateSerie
{
    public sealed class UpdateSerieHandler : IRequestHandler<UpdateSerieRequest, UpdateSerieResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISeriesRepository _seriesRepository;
        private readonly IMapper _mapper;

        public UpdateSerieHandler(IUnitOfWork unitOfWork, ISeriesRepository seriesRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _seriesRepository = seriesRepository;
            _mapper = mapper;
        }

        public async Task<UpdateSerieResponse> Handle(UpdateSerieRequest request, CancellationToken cancellationToken)
        {
            _mapper.Map<Domain.Entities.Serie>(request);

            var serie = await _seriesRepository.Get(request.Id, cancellationToken);
            if (serie == null) return default;


            serie.Title = request.Title;
            serie.Creator = request.Creator;
            serie.Description = request.Description;
            serie.AgeGroup = request.AgeGroup;
            serie.ReleaseYear = request.ReleaseYear;

            _seriesRepository.Update(serie);

            await _unitOfWork.Commit(cancellationToken);
            return _mapper.Map<UpdateSerieResponse>(serie);
        }
    }
}
